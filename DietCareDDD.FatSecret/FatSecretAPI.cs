using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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


            var normalizedParameters = "format=" + format
                                     + "&method=" + method
                                     + "&oauth_consumer_key=" + consumerKey
                                     + "&oauth_nonce=" + nonce
                                     + "&oauth_signature_method=" + signatureMethod
                                     + "&oauth_timestamp=" + timestamp
                                     + "&oauth_version=" + version
                                     + "&search_expression=" + "banana";
                                                           
            var httpMethod = "GET";
            var encodedUri = OAuthTools.UrlEncodeStrict(baseURL.Substring(0, baseURL.Length-1));
            var encodedNormalizedParameters = OAuthTools.UrlEncodeStrict(normalizedParameters);
            var baseSignature = httpMethod + "&" + encodedUri + "&" + encodedNormalizedParameters;

            string signature;

            using (HMACSHA1 hmac = new HMACSHA1(Encoding.ASCII.GetBytes("5e1b6dc6e9e84451bc265d633b9fc0de&")))
            {
                byte[] hashPayLoad = hmac.ComputeHash(Encoding.ASCII.GetBytes(baseSignature));
                signature = Convert.ToBase64String(hashPayLoad);
            }

            string fullURL = baseURL + normalizedParameters 
                                     + "&oauth_signature=" + signature;

            String responseText = await Task.Run(() =>
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(fullURL) as HttpWebRequest;
                    request.Method = "GET";
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