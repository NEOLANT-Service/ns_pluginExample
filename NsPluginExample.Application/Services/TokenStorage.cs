using System;
using System.Linq;
using System.Threading.Tasks;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Domain.Contracts.UnitOfWorks;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Application.Services
{
    public class TokenStorage : ITokenStorage
    {
        private readonly INsPluginExampleUnitOfWork unitOfWork;
        private static OAuth2Token _token = null;

        public TokenStorage(INsPluginExampleUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public bool HasValue { get => _token != null; }

        public async Task AddTokenAsync(OAuth2Token token)
        {
            _token = null;
            unitOfWork.Tokens.RemoveAll();
            if (token != null)
            {
                unitOfWork.Tokens.Add(token);
            }
            await unitOfWork.CommitAsync();
            _token = token;

        }

        public async Task<OAuth2Token> GetTokeAsync()
        {
            if (_token != null)
                return await Task.FromResult(_token);
            _token = (await unitOfWork.Tokens.GetAllAsync()).FirstOrDefault();
            return _token;
        }
    }
}
