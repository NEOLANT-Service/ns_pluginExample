using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Application.Services
{
    /// <summary>
    /// Реализация сервиса аутентификации
    /// </summary>
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly HttpClient httpClient;
        private readonly OAuth2Config authConfig;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="httpClient"></param>
        public AuthenticatorService(HttpClient httpClient, OAuth2Config oauthConfig)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.authConfig = oauthConfig ?? throw new ArgumentNullException(nameof(oauthConfig));
        }

        public async Task<OAuth2Token> GetAccessTokenAsync()
        {
            var credential = GetCredentialsHeader();
            var content = GetStringContent();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credential);
            var response = await httpClient.PostAsync(authConfig.TokenEndpoint, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<OAuth2Token>(responseContent);
            
            return token;
        }

        protected StringContent GetStringContent()
        {
            var payload = $"grant_type=password&username={authConfig.UserName}&password={authConfig.UserPassword}";
            return new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        protected string GetCredentialsHeader()
        {
            var credentialsStr =authConfig.ClientId + ":" + authConfig.ClientSecret;
            var credentialsBytes = Encoding.ASCII.GetBytes(credentialsStr);
            return Convert.ToBase64String(credentialsBytes);
        }

        public Task<OAuth2Token> RefreshTokenAsync(OAuth2Token oldToken, CancellationToken cancelationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RevokeTokenAsync(OAuth2Token token)
        {
            throw new NotImplementedException();
        }
    }
}
