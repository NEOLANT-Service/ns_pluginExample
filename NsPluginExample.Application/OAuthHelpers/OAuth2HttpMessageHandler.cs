using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using NsPluginExample.Domain.Contracts.Services;

namespace NsPluginExample.Application.OAuthHelpers
{
    internal class OAuth2HttpMessageHandler : DelegatingHandler
    {
        private readonly INeosyntezClient authorizationService;

        /// <summary>
        /// Create OAuth2 http message handler instance.
        /// </summary>
        /// <param name="authorizationService">OAuth2 authorization service instance.</param>
        public OAuth2HttpMessageHandler(INeosyntezClient authorizationService)
        {
            this.authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        }

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!authorizationService.IsAuthorized)
                await authorizationService.Login();
            var token = await authorizationService.FetchToken(cancellationToken).ConfigureAwait(false);
            if (token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(token.Type, token.AccessToken);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
