using NsPluginExample.Domain.Contracts.Services;

namespace NsPluginExample.Application.Services
{
    public class NsObjectsService : INsObjectsService
    {
        private readonly INeosyntezClient neosyntezClient;
        private readonly string baseUrl;

        public NsObjectsService(
            INeosyntezClient neosyntezClient,
            string baseUrl)
        {
            this.neosyntezClient = neosyntezClient ?? throw new System.ArgumentNullException(nameof(neosyntezClient));
            this.baseUrl = baseUrl ?? throw new System.ArgumentNullException(nameof(baseUrl));
        }
    }
}
