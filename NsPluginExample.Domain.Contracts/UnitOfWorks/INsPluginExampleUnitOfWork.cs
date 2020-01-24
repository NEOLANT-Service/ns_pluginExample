using DAL.Common;
using NsPluginExample.Domain.Contracts.Repositories;

namespace NsPluginExample.Domain.Contracts.UnitOfWorks
{
    public interface INsPluginExampleUnitOfWork:IUnitOfWork
    {
        IOAuthTokensRepository Tokens { get; }

    }
}
