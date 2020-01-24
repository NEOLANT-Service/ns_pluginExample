using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NsApiClient;
using NsApiClient.Extensions;
using NsPluginExample.Application.OAuthHelpers;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Application.Services
{
    public class NeosyntezClient : INeosyntezClient
    {
        private readonly ILogger<NeosyntezClient> logger;
        private readonly ITokenStorage tokenStorage;
        private readonly HttpClient httpClient;
        private readonly IAuthenticatorService authenticator;
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Create instance of Neosyntez client.
        /// </summary>
        public NeosyntezClient(
            ILogger<NeosyntezClient> logger,
            ITokenStorage tokenStorage,
            Func<HttpClient, IAuthenticatorService> authenticatorFactory)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.tokenStorage = tokenStorage ?? throw new ArgumentNullException(nameof(tokenStorage));

            httpClient = new HttpClient();
            authenticator = authenticatorFactory?.Invoke(httpClient) ??
                            throw new ArgumentNullException(nameof(authenticatorFactory));
        }

        /// <summary>
        /// Get Api client.
        /// </summary>
        /// <param name="baseUrl">Base url.</param>
        /// <returns></returns>
        public Client GetApiClient(string baseUrl)
        {
            var httpApiPipeline = new HttpClientHandler()
                .DecorateWith(new OAuth2HttpMessageHandler(this));
            var httpApiClient = new HttpClient(httpApiPipeline, true);

            return new Client(baseUrl, httpApiClient);
        }

        /// <inheritdoc />
        public bool IsAuthorized => tokenStorage.HasValue;

        /// <inheritdoc />
        public async Task<OAuth2Token> FetchToken(CancellationToken ct = default)
        {
            var token = await tokenStorage.GetTokeAsync().ConfigureAwait(false);

            if (token == null)
            {
                logger.LogTrace("No stored token found.");
                return null;
            }

            if (!token.IsExpired)
            {
                logger.LogTrace("Existing token returned.");
                return token;
            }

            try
            {
                semaphore.Wait(ct);
                logger.LogTrace("Try refresh token.");

                token = await authenticator.RefreshTokenAsync(token, ct)
                    .ConfigureAwait(false);
                await tokenStorage.AddTokenAsync(token).ConfigureAwait(false);
                return token;
            }
            catch (Exception exception)
            {
                logger.LogError("Failed refresh token: {Message}", exception.Message);

                await tokenStorage.AddTokenAsync(null).ConfigureAwait(false);
                return null;
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <inheritdoc />
        public async Task Login()
        {
            try
            {
                semaphore.Wait();

                var token = await authenticator.GetAccessTokenAsync().ConfigureAwait(false);
                await tokenStorage.AddTokenAsync(token).ConfigureAwait(false);
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <inheritdoc />
        public async Task Logout()
        {
            try
            {
                semaphore.Wait();
                var token = await tokenStorage.GetTokeAsync();
                if (token != null)
                {
                    await authenticator.RevokeTokenAsync(token);
                    await tokenStorage.AddTokenAsync(null).ConfigureAwait(false);
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            httpClient?.Dispose();
            semaphore?.Dispose();
        }
    }
}
