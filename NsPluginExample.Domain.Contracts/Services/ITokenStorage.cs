using System;
using System.Threading.Tasks;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Domain.Contracts.Services
{
    public interface ITokenStorage
    {
        bool HasValue { get; }

        Task<OAuth2Token> GetTokeAsync();

        Task AddTokenAsync(OAuth2Token token);
    }
}
