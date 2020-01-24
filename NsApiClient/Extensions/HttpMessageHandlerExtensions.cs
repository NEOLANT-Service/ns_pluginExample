using System;
using System.Net.Http;

namespace NsApiClient.Extensions
{
    public static class HttpMessageHandlerExtensions
    {
        /// <summary>
        /// Decorate <paramref name="parentHandler"/> with <paramref name="innerHandler"/>.
        /// </summary>
        /// <param name="innerHandler">Inner handler.</param>
        /// <param name="parentHandler">Parent handler.</param>
        /// <returns>Parent handler <paramref name="parentHandler"/>.</returns>
        public static DelegatingHandler DecorateWith(this HttpMessageHandler innerHandler, DelegatingHandler parentHandler)
        {
            if (parentHandler == null) throw new ArgumentNullException(nameof(parentHandler));
            parentHandler.InnerHandler = innerHandler ?? throw new ArgumentNullException(nameof(innerHandler));

            return parentHandler;
        }
    }
}
