using System;
using DAL.Common;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Domain.Contracts.Repositories
{
    /// <summary>
    /// Абстракция репозитория токенов безопасности
    /// </summary>
    public interface IOAuthTokensRepository : IDbRepository<OAuth2Token, Guid>
    {
    }
}
