using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using OAuth;

namespace DietCareDDD.FatSecret
{
    public class FatSecretAPI
    {
        public async Task<string> buscarAlimento(string alimento)
        {
            const string baseURL = "http://platform.fatsecret.com/rest/server.api?";

            const string consumerKey = "89a75f2dda9748d08cc87d573992fecb";
            string signatureMethod   = "HMAC-SHA1";
            string timestamp         = OAuthTools.GetTimestamp();
            string nonce             = OAuthTools.GetNonce();
            const string version     = "1.0";
            const string method      = "foods.search";
            const string format      = "json";

            var normalizedParameters = "oauth_consumer_key=" + consumerKey
                                     + "&oauth_signature_method=" + signatureMethod
                                     + "&oauth_timestamp=" + timestamp
                                     + "&oauth_nonce=" + nonce
                                     + "&oauth_version=" + version;
            var httpMethod = "GET";
            var encodedUri = OAuthTools.UrlEncodeStrict(baseURL);
            var encodedNormalizedParameters = OAuthTools.UrlEncodeStrict(normalizedParameters);
            var baseSignature = httpMethod + "&" + encodedUri + "&" + encodedNormalizedParameters;

            string signature = OAuthTools.GetSignature(OAuthSignatureMethod.HmacSha1,  OAuthSignatureTreatment.Escaped,  baseSignature, "5e1b6dc6e9e84451bc265d633b9fc0de");

            string fullURL = baseURL + normalizedParameters 
                                     + "&oauth_signature="        + signature
                                     + "&method="                 + method
                                     + "&format="                 + format
                                     + "&search_expression="      + alimento;

            String responseText = await Task.Run(() =>
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(fullURL) as HttpWebRequest;
                    WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    return new StreamReader(responseStream).ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

                return null;
            });

            return responseText;
        }
    }
}