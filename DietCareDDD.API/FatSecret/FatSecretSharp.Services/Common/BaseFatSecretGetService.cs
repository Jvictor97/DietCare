using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service4u2.Json;
using Service4u2.Common;
using System.Threading;

namespace FatSecretSharp.Services.Common
{
    public abstract class BaseFatSecretGetService<TRequest, TResponse> : BaseJsonService<TResponse>
        where TResponse : new()
    {
        protected FatSecretUrlBuilder builder;
        protected string ConsumerKey = string.Empty;
        protected string ConsumerSecret = string.Empty;
        protected string Method = string.Empty;
        protected string Format = "json";

        protected Dictionary<string, string> GenerateMethodAndFormatParmsDictionary()
        {
            return new Dictionary<string, string>
                {
                    { "method", this.Method },
                    { "format", this.Format },
                };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFatSecretGetService&lt;TRequest, TResponse&gt;"/> class.
        /// </summary>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="method">The api method name.</param>
        public BaseFatSecretGetService(string consumerKey, string consumerSecret, string method)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Method = method;

            builder = new FatSecretUrlBuilder(ConsumerKey, ConsumerSecret);
        }

        /// <summary>
        /// Creates the request URL.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A request url determined by the request.</returns>
        protected abstract string CreateRequestUrl(TRequest request);

        /// <summary>
        /// Starts the service request.
        /// </summary>
        /// <param name="request">The request details.</param>
        public void StartRequestAsync(TRequest request)
        {
            if (String.IsNullOrEmpty(ConsumerKey))
                throw new ArgumentNullException("The Consumer Key is not set.");
            if (String.IsNullOrEmpty(ConsumerSecret))
                throw new ArgumentNullException("The Consumer Secret is not set.");
            
            var requestUrl = CreateRequestUrl(request);

            StartServiceCall(requestUrl);
        }

        /// <summary>
        /// Gets the response synchronously.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A parsed response, or throws an exception.</returns>
        public TResponse GetResponseSynchronously(TRequest request)
        {
            return RunServiceSynch(this, (s) => s.StartRequestAsync(request));
        }

        /// <summary>
        /// A helper method that runs the service synchronously by polling for finish.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="service">The service.</param>
        /// <param name="startAction">The start action.</param>
        /// <returns>The parsed response, or null if an exception occured.</returns>
        protected static TResponse RunServiceSynch<TService>(TService service, Action<TService> startAction)
            where TService : IAsyncService<TResponse>
        {
            bool serviceDone = false;
            TResponse response = default(TResponse);

            Action<object, EventArgs<Exception>> err = (s, e) =>
            {
                response = default(TResponse);
                serviceDone = true;
            };

            Action<object, EventArgs<TResponse>> res = (s, e) =>
            {
                response = e.Argument;
                serviceDone = true;
            };

            var gotErr = new EventHandler<EventArgs<Exception>>(err);
            var gotRes = new EventHandler<EventArgs<TResponse>>(res);

            // Add our handlers that let us know we are done.
            service.GotError += gotErr;
            service.GotResult += gotRes;

            startAction(service);

            DateTime start = DateTime.Now;
            // Start polling.  Wait a maximum of 20 seconds.
            while (!serviceDone && (DateTime.Now.Subtract(start).TotalSeconds < 20))
            {   
                Thread.Sleep(1000);
            }

            if (!serviceDone && (DateTime.Now.Subtract(start).TotalSeconds >= 20))
            {
                // Set a default response if we timed out.
                response = default(TResponse);
            }

            // Remove our handlers to prevent future manipulation.
            service.GotError -= gotErr;
            service.GotResult -= gotRes;

            return response;
        }
    }
}
