using System.Threading;
using System.Threading.Tasks;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Domain.Contracts.Services
{
    /// <summary>
    /// Аутентификатор
    /// </summary>
    public interface IAuthenticatorService
    {
        /// <summary>
        /// Вернет токен безопасности
        /// </summary>
        /// <returns></returns>
        Task<OAuth2Token> GetAccessTokenAsync();

        /// <summary>
        /// Обновит токен безопасности
        /// </summary>
        /// <param name="oldToken">Истекший токен</param>
        /// <returns></returns>
        Task<OAuth2Token> RefreshTokenAsync(OAuth2Token oldToken, CancellationToken cancelationToken = default);

        /// <summary>
        /// Отзовет токен
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns></returns>
        Task RevokeTokenAsync(OAuth2Token token);
    }
}
