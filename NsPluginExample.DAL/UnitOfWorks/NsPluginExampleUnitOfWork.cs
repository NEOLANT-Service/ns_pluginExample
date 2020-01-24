using NsPluginExample.DAL.Contexts;
using NsPluginExample.DAL.Repositories;
using NsPluginExample.DAL.UnitOfWorks.Common;
using NsPluginExample.Domain.Contracts.Repositories;
using NsPluginExample.Domain.Contracts.UnitOfWorks;

namespace NsPluginExample.DAL.UnitOfWorks
{
    public class NsPluginExampleUnitOfWork : UnitOfWork<NsPluginExampleContext>, INsPluginExampleUnitOfWork
    {
        IOAuthTokensRepository tokens = null;

        public NsPluginExampleUnitOfWork(NsPluginExampleContext context) : base(context)
        {

        }

        public IOAuthTokensRepository Tokens { get => tokens = tokens ?? new OAuthTokensRepository(context); }
    }
}
