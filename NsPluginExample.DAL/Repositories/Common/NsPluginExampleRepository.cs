using NsPluginExample.DAL.Contexts;

namespace NsPluginExample.DAL.Repositories.Common
{
    public abstract class NsPluginExampleRepository<TEntity, TKey> : DbRepository<TEntity, TKey> where TEntity : class
    {
        private readonly new NsPluginExampleContext context;

        public NsPluginExampleRepository(NsPluginExampleContext context) : base(context)
        {
            this.context = context;
        }
    }
}
