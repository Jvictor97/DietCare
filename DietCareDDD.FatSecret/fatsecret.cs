using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Web;
using System.Net;
using System.IO;

namespace FatSecret
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string fatSecretRestUrl = "http://platform.fatsecret.com/rest/server.api";
        string consumer_key = "your_consumer_key";
        string consumer_secret = "your_consumer_secret";
        string oauth_signature_method = "HMAC-SHA1";
        string oauth_timestamp = "";
        string oauth_nonce = "";
        string oauth_version = "1.0";
        string method = "";
        string search_term = "banana";
        string http_method = "POST";

        string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
      
        public void foodsSearch()//Search food with term
        {
            //Create Parameters            
            oauth_timestamp = createTimestamp();
            oauth_nonce = createNonce();
            method = "foods.search";

            string urlBase = fatSecretRestUrl + "?" + "method=" + method;
            Uri url = new Uri(urlBase);

            string str = "";
            string[] t = txtSearchTerm.Text.Split(' ');
            foreach (string s in t)
            {
                str += s;
            }
            search_term = str;

            //Create the parameter List
            var parameters = new List<QueryParameters>();

            //QueryParameters pMaxResults = new QueryParameters();
            //pMaxResults.name = "max_results"; pMaxResults.value = "50"; parameters.Add(pMaxResults);
            QueryParameters pMethod = new QueryParameters();
            pMethod.name = "method"; pMethod.value = method; parameters.Add(pMethod);
            QueryParameters pConsumerKey = new QueryParameters();
            pConsumerKey.name = "oauth_consumer_key"; pConsumerKey.value = consumer_key; parameters.Add(pConsumerKey);
            QueryParameters pNonce = new QueryParameters();
            pNonce.name = "oauth_nonce"; pNonce.value = oauth_nonce; parameters.Add(pNonce);
            QueryParameters pSignatureMethod = new QueryParameters();
            pSignatureMethod.name = "oauth_signature_method"; pSignatureMethod.value = oauth_signature_method; parameters.Add(pSignatureMethod);
            QueryParameters pTimestamp = new QueryParameters();
            pTimestamp.name = "oauth_timestamp"; pTimestamp.value = oauth_timestamp; parameters.Add(pTimestamp);
            QueryParameters pVersion = new QueryParameters();
            pVersion.name = "oauth_version"; pVersion.value = oauth_version; parameters.Add(pVersion);
            //QueryParameters pPageNumber = new QueryParameters();
            //pPageNumber.name = "page_number"; pPageNumber.value = "0"; parameters.Add(pPageNumber);
            QueryParameters pSearchExpression = new QueryParameters();
            pSearchExpression.name = "search_expression"; pSearchExpression.value = search_term; parameters.Add(pSearchExpression);
            //parameters.Sort();

            //Check Url
            string normalizedUrl = string.Format("{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
            {
                normalizedUrl += ":" + url.Port;
            }
            normalizedUrl += url.AbsolutePath;

            //Put parameters to Url
            string normalizedRequestParameters;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parameters.Count; i++)
            {
                sb.AppendFormat("{0}={1}", parameters[i].name, parameters[i].value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }
            normalizedRequestParameters = sb.ToString();

            //Build the SignatureBase String
            StringBuilder signatureBaseBulder = new StringBuilder();
            signatureBaseBulder.AppendFormat("{0}&", http_method);
            signatureBaseBulder.AppendFormat("{0}&", UrlEncode(normalizedUrl));
            signatureBaseBulder.AppendFormat("{0}", UrlEncode(normalizedRequestParameters));

            string signatureBase = signatureBaseBulder.ToString();

            //Create Signature
            string tokenSecret = null;
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", UrlEncode(consumer_secret), isNullOrEmpty(tokenSecret) ? "" : UrlEncode(tokenSecret)));

            string signature;
            byte[] dataBuffer = Encoding.ASCII.GetBytes(signatureBase);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            signature = Convert.ToBase64String(hashBytes);

            string requestUrl = normalizedUrl;
            string postString = normalizedRequestParameters + "&" + "oauth_signature=" + HttpUtility.UrlEncode(signature);

            //Send Request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            webRequest.Method = http_method;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            byte[] parameterString = Encoding.ASCII.GetBytes(postString);
            webRequest.ContentLength = parameterString.Length;
            using (Stream buffer = webRequest.GetRequestStream())
            {
                buffer.Write(parameterString, 0, parameterString.Length);
                buffer.Close();
            }

            WebResponse webResponse = webRequest.GetResponse();
            string responseData;
            using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                responseData = streamReader.ReadToEnd();
            }

            //Write to XML file
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(responseData);

            XmlDocument doc = xmlDocument;
            //doc.Save("C:\\Users\\a584963\\Desktop\\data.xml");

            MessageBox.Show(doc.OuterXml);
        }

        public void foodGet()//Get food details with id
        {
            oauth_timestamp = createTimestamp();
            oauth_nonce = createNonce();
            method = "food.get";
            string foodId = txtGetID.Text;//Water:518955 Cookie:5493710 Cola:37903

            string urlBase = fatSecretRestUrl + "?" + "method=" + method;
            Uri url = new Uri(urlBase);

            string str = "";
            string[] t = txtSearchTerm.Text.Split(' ');
            foreach (string s in t)
            {
                str += s;
            }
            search_term = str;

            //Create the parameter List
            var parameters = new List<QueryParameters>();

            QueryParameters pFoodId = new QueryParameters();
            pFoodId.name = "food_id"; pFoodId.value = foodId; parameters.Add(pFoodId);
            QueryParameters pMethod = new QueryParameters();
            pMethod.name = "method"; pMethod.value = method; parameters.Add(pMethod);
            QueryParameters pConsumerKey = new QueryParameters();
            pConsumerKey.name = "oauth_consumer_key"; pConsumerKey.value = consumer_key; parameters.Add(pConsumerKey);
            QueryParameters pNonce = new QueryParameters();
            pNonce.name = "oauth_nonce"; pNonce.value = oauth_nonce; parameters.Add(pNonce);
            QueryParameters pSignatureMethod = new QueryParameters();
            pSignatureMethod.name = "oauth_signature_method"; pSignatureMethod.value = oauth_signature_method; parameters.Add(pSignatureMethod);
            QueryParameters pTimestamp = new QueryParameters();
            pTimestamp.name = "oauth_timestamp"; pTimestamp.value = oauth_timestamp; parameters.Add(pTimestamp);
            QueryParameters pVersion = new QueryParameters();
            pVersion.name = "oauth_version"; pVersion.value = oauth_version; parameters.Add(pVersion);
            //parameters.Sort();

            //Check Url
            string normalizedUrl = string.Format("{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
            {
                normalizedUrl += ":" + url.Port;
            }
            normalizedUrl += url.AbsolutePath;

            //Put parameters to Url
            string normalizedRequestParameters;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parameters.Count; i++)
            {
                sb.AppendFormat("{0}={1}", parameters[i].name, parameters[i].value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }
            normalizedRequestParameters = sb.ToString();

            //Build the SignatureBase String
            StringBuilder signatureBaseBulder = new StringBuilder();
            signatureBaseBulder.AppendFormat("{0}&", http_method);
            signatureBaseBulder.AppendFormat("{0}&", UrlEncode(normalizedUrl));
            signatureBaseBulder.AppendFormat("{0}", UrlEncode(normalizedRequestParameters));

            string signatureBase = signatureBaseBulder.ToString();

            //Create Signature
            string tokenSecret = null;
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", UrlEncode(consumer_secret), isNullOrEmpty(tokenSecret) ? "" : UrlEncode(tokenSecret)));

            string signature;
            byte[] dataBuffer = Encoding.ASCII.GetBytes(signatureBase);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            signature = Convert.ToBase64String(hashBytes);

            string requestUrl = normalizedUrl;
            string postString = normalizedRequestParameters + "&" + "oauth_signature=" + HttpUtility.UrlEncode(signature);

            //Send Request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            webRequest.Method = http_method;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            byte[] parameterString = Encoding.ASCII.GetBytes(postString);
            webRequest.ContentLength = parameterString.Length;
            using (Stream buffer = webRequest.GetRequestStream())
            {
                buffer.Write(parameterString, 0, parameterString.Length);
                buffer.Close();
            }

            WebResponse webResponse = webRequest.GetResponse();
            string responseData;
            using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                responseData = streamReader.ReadToEnd();
            }

            //Write to XML file
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(responseData);

            XmlDocument doc = xmlDocument;
            //doc.Save("Path\file.xml");

            //MessageBox.Show(doc.OuterXml);

            foodDetails(doc.OuterXml);
        }

        public void foodDetails(string xml)//Parse json with own method
        {
            food f = new food();

            string[] stringeparatorsFood = new string[] { "<", ">" };
            string[] foodArray = xml.Split(stringeparatorsFood, StringSplitOptions.None);

            foodArray = foodArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            int servingsBegin = 0;
            int servingsCount = 0;

            for (int i = 0; i < foodArray.Count(); i++)
            {
                if (foodArray[i].Contains("food_url"))
                    servingsBegin = i + 1;
                if (foodArray[i].Contains("serving_id"))
                    servingsCount++;
            }
            if (servingsCount != 0)
                servingsCount = servingsCount / 2;

            for (int i = 0; i < servingsBegin; i++)
            {
                switch (foodArray[i])
                {
                    case "food_id":
                        f.food_id = foodArray[i + 1]; i += 1; break;
                    case "food_name":
                        f.food_name = foodArray[i + 1]; i += 1; break;
                    case "brand_name":
                        f.brand_name = foodArray[i + 1]; i += 1; break;
                    case "food_type":
                        f.food_type = foodArray[i + 1]; i += 1; break;
                    case "food_url":
                        f.food_url = foodArray[i + 1]; i += 1; break;

                }
                i += 1;
            }
            var servingsList = new List<serving>();
            var s = new serving();

            for (int i = servingsBegin; i < foodArray.Count(); i++)
            {
                switch (foodArray[i])
                {
                    case "serving_id":
                        s = new serving();
                        s.serving_id = foodArray[i + 1]; i += 1; break;
                    case "serving_description":
                        s.serving_description = foodArray[i + 1]; i += 1; break;
                    case "serving_url":
                        s.serving_url = foodArray[i + 1]; i += 1; break;
                    case "metric_serving_amount":
                        s.metric_serving_amount = foodArray[i + 1]; i += 1; break;
                    case "metric_serving_unit":
                        s.metric_serving_unit = foodArray[i + 1]; i += 1; break;
                    case "number_of_units":
                        s.number_of_units = foodArray[i + 1]; i += 1; break;
                    case "measurement_description":
                        s.measurement_description = foodArray[i + 1]; i += 1; break;
                    case "calories":
                        s.calories = foodArray[i + 1]; i += 1; break;
                    case "carbohydrate":
                        s.carbohydrate = foodArray[i + 1]; i += 1; break;
                    case "protein":
                        s.protein = foodArray[i + 1]; i += 1; break;
                    case "fat":
                        s.fat = foodArray[i + 1]; i += 1; break;
                    case "saturated_fat":
                        s.saturated_fat = foodArray[i + 1]; i += 1; break;
                    case "polyunsaturated_fat":
                        s.polyunsaturated_fat = foodArray[i + 1]; i += 1; break;
                    case "monounsaturated_fat":
                        s.monounsaturated_fat = foodArray[i + 1]; i += 1; break;
                    case "trans_fat":
                        s.trans_fat = foodArray[i + 1]; i += 1; break;
                    case "cholesterol":
                        s.cholesterol = foodArray[i + 1]; i += 1; break;
                    case "sodium":
                        s.sodium = foodArray[i + 1]; i += 1; break;
                    case "potassium":
                        s.potassium = foodArray[i + 1]; i += 1; break;
                    case "fiber":
                        s.fiber = foodArray[i + 1]; i += 1; break;
                    case "sugar":
                        s.sugar = foodArray[i + 1]; i += 1; break;
                    case "vitamin_a":
                        s.vitamin_a = foodArray[i + 1]; i += 1; break;
                    case "vitamin_c":
                        s.vitamin_c = foodArray[i + 1]; i += 1; break;
                    case "calcium":
                        s.calcium = foodArray[i + 1]; i += 1; break;
                    case "iron":
                        s.iron = foodArray[i + 1]; i += 1;
                        servingsList.Add(s); break;
                }
            }
            f.servings = servingsList;

            MessageBox.Show("ID: " + f.food_id + Environment.NewLine +
                "Name: " + f.food_name + Environment.NewLine +
                "Brand: " + f.brand_name + Environment.NewLine +
                "Type: " + f.food_type + Environment.NewLine +
                "Url: " + f.food_url + Environment.NewLine +
                "Servings" + Environment.NewLine +
                "ID: " + f.servings[0].serving_id + Environment.NewLine +
                "Description: " + f.servings[0].serving_description + Environment.NewLine +
                "Url: " + f.servings[0].serving_url + Environment.NewLine +
                "Metric Serving Amount: " + f.servings[0].metric_serving_amount + Environment.NewLine +
                "Metric Serving Unit: " + f.servings[0].metric_serving_unit + Environment.NewLine +
                "Number of Units: " + f.servings[0].number_of_units + Environment.NewLine +
                "Measurement Description: " + f.servings[0].measurement_description + Environment.NewLine +
                "Calories: " + f.servings[0].calories + Environment.NewLine +
                "Carbohydrate: " + f.servings[0].carbohydrate + Environment.NewLine +
                "Protein: " + f.servings[0].protein + Environment.NewLine +
                "Fat: " + f.servings[0].fat + Environment.NewLine +
                "Saturated Fat: " + f.servings[0].saturated_fat + Environment.NewLine +
                "Polyunsaturated Fat: " + f.servings[0].polyunsaturated_fat + Environment.NewLine +
                "Monounsaturated Fat: " + f.servings[0].monounsaturated_fat + Environment.NewLine +
                "Trans Fat: " + f.servings[0].trans_fat + Environment.NewLine +
                "Cholesterol: " + f.servings[0].cholesterol + Environment.NewLine +
                "Sodium: " + f.servings[0].sodium + Environment.NewLine +
                "Potassium: " + f.servings[0].potassium + Environment.NewLine +
                "Fiber: " + f.servings[0].fiber + Environment.NewLine +
                "Sugar: " + f.servings[0].sugar + Environment.NewLine +
                "Vitamin A: " + f.servings[0].vitamin_a + Environment.NewLine +
                "Vitamin C:" + f.servings[0].vitamin_c + Environment.NewLine +
                "Caclcium: " + f.servings[0].calcium + Environment.NewLine +
                "Iron: " + f.servings[0].iron + Environment.NewLine
                );
        }


        public string createTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        public string createNonce()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }


        public string UrlEncode(string normalizedUrl)
        {
            StringBuilder r = new StringBuilder();
            foreach (char symbol in normalizedUrl)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    r.Append(symbol);
                }
                else
                {
                    r.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }
            return r.ToString();
        }
        public bool isNullOrEmpty(string str)
        {
            return (str == null || str.Length == 0);
        }

        
    }
}
