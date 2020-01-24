using System;
using NsPluginExample.DAL.Contexts;
using NsPluginExample.DAL.Repositories.Common;
using NsPluginExample.Domain.Contracts.Repositories;
using NsPluginExample.Domain.Models.NsModels.OAuth;

namespace NsPluginExample.Application.Repositories
{
    public class OAuthTokensRepository : DbRepository<OAuth2Token, Guid>, IOAuthTokensRepository
    {
        private new NsPluginExampleContext context = null;

        public OAuthTokensRepository(NsPluginExampleContext context) : base(context)
        {
            this.context = context;
        }
    }
}
