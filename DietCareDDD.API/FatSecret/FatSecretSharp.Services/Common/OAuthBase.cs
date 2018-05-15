using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FatSecretSharp.Services.Common
{
    public class OAuthBase
    {
        // Fields
        public const string OAUTH_CALLBACK = "oauth_callback";
        public const string OAUTH_CONSUMER_KEY = "oauth_consumer_key";
        public const string OAUTH_NONCE = "oauth_nonce";
        public const string OAUTH_PARAMETER_PREFIX = "oauth_";
        public const string OAUTH_SIGNATURE = "oauth_signature";
        public const string OAUTH_SIGNATURE_METHOD = "oauth_signature_method";
        public const string OAUTH_TIMESTAMP = "oauth_timestamp";
        public const string OAUTH_TOKEN = "oauth_token";
        public const string OAUTH_TOKEN_SECRET = "oauth_token_secret";
        public const string OAUTH_VERSION = "oauth_version";
        public const string OAUTH_VERSION_NUMBER = "1.0";
        public const string OPEN_SOCIAL_PARAMETER_PREFIX = "opensocial_";
        protected string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
        public const string XOAUTH_PARAMETER_PREFIX = "xoauth_";

        // Methods
        private string ComputeHash(HashAlgorithm hashAlgorithm, string data)
        {
            byte[] bytes = Encoding.GetEncoding("ASCII").GetBytes(data);
            return Convert.ToBase64String(hashAlgorithm.ComputeHash(bytes));
        }

        private string GenerateNonce()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public string GenerateSignature(Uri url, string consumerKey, string consumerSecret, string httpMethod, string token, string tokenSecret, out string normalizedUrl, out string normalizedRequestParameters)
        {
            normalizedUrl = null;
            normalizedRequestParameters = null;
            string signatureBase = this.GenerateSignatureBase(url, consumerKey, token, httpMethod.ToUpper(), this.GenerateTimeStamp(), this.GenerateNonce(), "HMAC-SHA1", out normalizedUrl, out normalizedRequestParameters);
            HMACSHA1 hash = new HMACSHA1();
            hash.Key = Encoding.GetEncoding("ASCII").GetBytes(string.Format("{0}&{1}", this.UrlEncode(consumerSecret), IsNullOrEmpty(tokenSecret) ? "" : this.UrlEncode(tokenSecret)));
            return this.GenerateSignatureUsingHash(signatureBase, hash);
        }

        private string GenerateSignatureBase(Uri url, string consumerKey, string token, string httpMethod, string timeStamp, string nonce, string signatureType, out string normalizedUrl, out string normalizedRequestParameters)
        {
            normalizedUrl = null;
            normalizedRequestParameters = null;
            IList result = new List<QueryParameter>();
            this.GetQueryParameters(url.Query, result);
            result.Add(new QueryParameter("oauth_version", "1.0"));
            result.Add(new QueryParameter("oauth_nonce", nonce));
            result.Add(new QueryParameter("oauth_timestamp", timeStamp));
            result.Add(new QueryParameter("oauth_signature_method", signatureType));
            result.Add(new QueryParameter("oauth_consumer_key", consumerKey));
            if (!IsNullOrEmpty(token))
            {
                result.Add(new QueryParameter("oauth_token", token));
            }
            ((List<QueryParameter>)result).Sort(new QueryParameterComparer());
            normalizedUrl = string.Format("{0}://{1}", url.Scheme, url.Host);
            if (((url.Scheme != "http") || (url.Port != 80)) && ((url.Scheme != "https") || (url.Port != 0x1bb)))
            {
                normalizedUrl = normalizedUrl + ":" + url.Port;
            }
            normalizedUrl = normalizedUrl + url.AbsolutePath;
            normalizedRequestParameters = this.NormalizeRequestParameters(result);
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}&", httpMethod);
            builder.AppendFormat("{0}&", this.UrlEncode(normalizedUrl));
            builder.AppendFormat("{0}", this.UrlEncode(normalizedRequestParameters));
            return builder.ToString();
        }

        private string GenerateSignatureUsingHash(string signatureBase, HashAlgorithm hash)
        {
            return this.ComputeHash(hash, signatureBase);
        }

        private string GenerateTimeStamp()
        {
            TimeSpan span = (TimeSpan)(DateTime.UtcNow - new DateTime(0x7b2, 1, 1, 0, 0, 0, 0));
            return Convert.ToInt64(span.TotalSeconds).ToString();
        }

        private IList GetQueryParameters(string parameters, IList result)
        {
            if (parameters.StartsWith("?"))
            {
                parameters = parameters.Remove(0, 1);
            }
            if (!IsNullOrEmpty(parameters))
            {
                foreach (string str in parameters.Split(new char[] { '&' }))
                {
                    // Doesnt start with oauth_ (except for oauth_token, which is required for profile.get.
                    if (!IsNullOrEmpty(str) 
                        && !str.StartsWith("oauth_")
                        && !str.StartsWith("xoauth_") 
                        && !str.StartsWith("opensocial_"))
                    {
                        if (str.IndexOf('=') > -1)
                        {
                            string[] strArray2 = str.Split(new char[] { '=' });
                            result.Add(new QueryParameter(strArray2[0], this.UrlEncode(strArray2[1])));
                        }
                        else
                        {
                            result.Add(new QueryParameter(str, string.Empty));
                        }
                    }
                }
            }
            return result;
        }

        private static bool IsNullOrEmpty(string str)
        {
            if (str != null)
            {
                return (str.Length == 0);
            }
            return true;
        }

        protected string NormalizeRequestParameters(IList parameters)
        {
            StringBuilder builder = new StringBuilder();
            QueryParameter parameter = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                parameter = (QueryParameter)parameters[i];
                builder.AppendFormat("{0}={1}", parameter.Name, parameter.Value);
                if (i < (parameters.Count - 1))
                {
                    builder.Append("&");
                }
            }
            return builder.ToString();
        }

        protected string UrlEncode(string value)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char ch in value)
            {
                if (this.unreservedChars.IndexOf(ch) != -1)
                {
                    builder.Append(ch);
                }
                else
                {
                    builder.Append('%' + string.Format("{0:X2}", (int)ch));
                }
            }
            return builder.ToString();
        }

        // Nested Types
        protected class QueryParameter
        {
            // Fields
            private string name = null;
            private string value = null;

            // Methods
            public QueryParameter(string name, string value)
            {
                this.name = name;
                this.value = value;
            }

            // Properties
            public string Name
            {
                get
                {
                    return this.name;
                }
            }

            public string Value
            {
                get
                {
                    return this.value;
                }
            }
        }

        protected class QueryParameterComparer : IComparer<QueryParameter>, IComparer
        {
            // Methods
            public int Compare(object a, object b)
            {
                QueryParameter parameter = (QueryParameter)a;
                QueryParameter parameter2 = (QueryParameter)b;
                if (parameter.Name == parameter2.Name)
                {
                    return string.Compare(parameter.Value, parameter2.Value);
                }
                return string.Compare(parameter.Name, parameter2.Name);
            }

            #region IComparer<QueryParameter> Members

            public int Compare(QueryParameter x, QueryParameter y)
            {
                return Compare((object)x, (object)y);
            }

            #endregion
        }
    }
}
