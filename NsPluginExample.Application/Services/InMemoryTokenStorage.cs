using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Application.Services
{
    public class InMemoryTokenStorage : ITokenStorage
    {
        private readonly IMemoryCache memoryCache;
        private const string KEY_NAME = "AuthToken";

        public InMemoryTokenStorage(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public bool HasValue
        {
            get{
                var token = GetTokeAsync().GetAwaiter().GetResult();
                return token != null;
            }
        }

        public Task AddTokenAsync(OAuth2Token token)
        {
            return Task.FromResult(memoryCache.Set(KEY_NAME, token));
        }

        public Task<OAuth2Token> GetTokeAsync()
        {
            if (memoryCache.TryGetValue(KEY_NAME, out OAuth2Token token))
                return Task.FromResult(token);
            return Task.FromResult<OAuth2Token>(null);
        }
    }
}
