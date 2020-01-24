using System;
using System.Threading;
using System.Threading.Tasks;
using NsApiClient;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Domain.Contracts.Services
{
    public interface INeosyntezClient
    {
        /// <summary>
        /// Gets is service authorized or not.
        /// </summary>
        bool IsAuthorized { get; }

        /// <summary>
        /// Fetch token.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns></returns>
        Task<OAuth2Token> FetchToken(CancellationToken ct = default);

        Client GetApiClient(string baseUrl);

        /// <summary>
        /// Login task.
        /// </summary>
        /// <returns></returns>
        Task Login();

        /// <summary>
        /// Logout task.
        /// </summary>
        /// <returns></returns>
        Task Logout();
    }
}
