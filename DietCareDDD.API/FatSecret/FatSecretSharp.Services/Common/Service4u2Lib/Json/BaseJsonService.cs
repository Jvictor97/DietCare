using System;
using System.Collections.Generic;
using System.Net;
using Service4u2.Common;
using FatSecretSharp.Services.Common.Service4u2Lib.Json;

namespace Service4u2.Json
{
    /// <summary>
    /// A simple enumeration for determining the method for the webclient to use when requesting data.
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// 
        /// </summary>
        GET = 0,
        /// <summary>
        /// 
        /// </summary>
        POST = 1
    }

    /// <summary>
    /// Type of content.
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// 
        /// </summary>
        UrlEncoded = 0,
        /// <summary>
        /// 
        /// </summary>
        JSON = 1
    }

    /// <summary>
    /// A base class for Json related services.
    /// </summary>
    /// <typeparam name="TResultType">The type of the result.</typeparam>
    public abstract class BaseJsonService<TResultType> : IAsyncService<TResultType>
        where TResultType : new()
    {
        protected WebClient client;

        /// <summary>
        /// Occurs when [got result].
        /// </summary>
        public event EventHandler<EventArgs<TResultType>> GotResult;

        /// <summary>
        /// Occurs when [got error].
        /// </summary>
        public event EventHandler<EventArgs<Exception>> GotError;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseJsonService&lt;TResultType&gt;"/> class.
        /// </summary>
        public BaseJsonService()
        {
            client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
        }

        /// <summary>
        /// Handles the UploadStringCompleted event of the client control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Net.UploadStringCompletedEventArgs"/> instance containing the event data.</param>
        void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                HandleClientError(e.Error);
                return;
            }

            HandleClientResultString(e.Result);
        }

        /// <summary>
        /// Handles the DownloadStringCompleted event of the client control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Net.DownloadStringCompletedEventArgs"/> instance containing the event data.</param>
        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                HandleClientError(e.Error);
                return;
            }

            HandleClientResultString(e.Result);
        }

        /// <summary>
        /// Handles the client error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private void HandleClientError(Exception exception)
        {
            if (GotError != null)
                GotError(this, new EventArgs<Exception>() { Argument = exception });
        }

        /// <summary>
        /// Handles the client result string.
        /// </summary>
        /// <param name="downloadedString">The downloaded string.</param>
        private void HandleClientResultString(string downloadedString)
        {
            // Check for html doctype and report error if found.
            int takeLength = downloadedString.Length > 20 ? 20 : downloadedString.Length;
            if (downloadedString.Substring(0, takeLength).Contains("!DOCTYPE html"))
            {
                HandleClientError(new NotSupportedException("The service call returned html and not json"));
                return;
            }

            var result = new TResultType();

            string json = downloadedString;

            if (result is IJSONMassager)
            {                
                json = ((IJSONMassager)result).MassageJSON(downloadedString);
            }

            if (result is IJSONSelfSerialize<TResultType>)
            {
                result = ((IJSONSelfSerialize<TResultType>)result).SelfSerialize(json);
            }
            else
                result = JsonHelper.Deserialize<TResultType>(json);

            if (GotResult != null)
                GotResult(this, new EventArgs<TResultType>() { Argument = result });
        }

        /// <summary>
        /// Starts the service call.
        /// </summary>
        /// <param name="uriString">The URI string.</param>
        protected void StartServiceCall(string uriString)
        {
            StartServiceCall(new Uri(uriString));
        }

        /// <summary>
        /// Starts the service call.
        /// </summary>
        /// <param name="uriString">The URI string.</param>
        /// <param name="method">The method.</param>
        protected void StartServiceCall(string uriString, HttpMethod method)
        {
            StartServiceCall(new Uri(uriString), method);
        }

        /// <summary>
        /// Starts the service call.
        /// </summary>
        /// <param name="uri">The URI.</param>
        protected void StartServiceCall(Uri uri)
        {
            StartServiceCall(uri, HttpMethod.GET);
        }

        /// <summary>
        /// Starts the service call.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="method">The method.</param>
        protected virtual void StartServiceCall(Uri serviceUri, HttpMethod method)
        {
            StartServiceCall(serviceUri, method, ContentType.UrlEncoded, string.Empty);
        }

        /// <summary>
        /// Starts the service call.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="postData">The post data.</param>
        protected virtual void StartServiceCall(Uri serviceUri, Dictionary<string, object> postData)
        {
            StartServiceCall(serviceUri, HttpMethod.POST, ContentType.UrlEncoded, postData.Postify());
        }

        /// <summary>
        /// Starts the service call.
        /// </summary>
        /// <typeparam name="TPostType">The type of the post type.</typeparam>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="postData">The post data.</param>
        protected virtual void StartServiceCall<TPostType>(Uri serviceUri, TPostType postData)
            where TPostType : class
        {
            StartServiceCall(serviceUri, HttpMethod.POST, ContentType.UrlEncoded, postData.Postify());
        }

        protected virtual void StartServiceCall(string serviceUri, HttpMethod method, string postData)
        {
            StartServiceCall(new Uri(serviceUri), method, ContentType.UrlEncoded, postData);
        }

        protected virtual void StartServiceCall(string serviceUri, HttpMethod method, ContentType type, string postData)
        {
            StartServiceCall(new Uri(serviceUri), method, type, postData);
        }

        protected virtual void StartServiceCall(Uri serviceUri, HttpMethod method, string postData)
        {
            StartServiceCall(serviceUri, method, ContentType.UrlEncoded, postData);
        }

        /// <summary>
        /// Starts the service call.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="method">The method.</param>
        /// <param name="postData">The post data.</param>
        protected virtual void StartServiceCall(Uri serviceUri, HttpMethod method, ContentType type, string postData)
        {

            if (method == HttpMethod.GET)
            {
                // Remove the content type header, in case it messes with our get.
                if (client.Headers["Content-Type"] != null)
                    client.Headers["Content-Type"] = null;

                client.DownloadStringAsync(serviceUri);
            }
            else
            {
                switch (type)
                {
                    case ContentType.UrlEncoded:
                        client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                        break;
                    case ContentType.JSON:
                        client.Headers["Content-Type"] = "application/json";
                        break;
                    default:
                        client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                        break;
                }
                client.UploadStringAsync(serviceUri, "POST", postData);
            }
        }
    }
}
