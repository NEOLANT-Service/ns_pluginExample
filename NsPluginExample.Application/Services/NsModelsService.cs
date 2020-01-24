using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NsApiModels;
using NsPluginExample.Domain.Contracts.Services;

namespace NsPluginExample.Application.Services
{
    public class NsModelsService : INsModelsService
    {
        private readonly INeosyntezClient neosyntezClient;
        private readonly string baseUrl;

        public NsModelsService(
            INeosyntezClient neosyntezClient,
            string baseUrl)
        {
            this.neosyntezClient = neosyntezClient ?? throw new ArgumentNullException(nameof(neosyntezClient));
            this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public Task<ICollection<ContentValue>> GetModelContentAsync(long id)
        {
            return neosyntezClient.GetApiClient(baseUrl).ContentAllAsync(id);
        }

        public Task<ICollection<NodeNg>> GetModelsAsync(long? id = null)
        {
            return neosyntezClient.GetApiClient(baseUrl).GetModelsAsync(id, null, false);
        }

        public Task<ContentValue> GetP3DBFile(long id, Guid contentId)
        {
            return neosyntezClient.GetApiClient(baseUrl).Content2Async(contentId, id.ToString());
        }

        /// <summary>
        /// Вернет лицензию для p3db plugin
        /// </summary>
        /// <returns></returns>
        public Task<ContentValue> GetP3DBLicence()
        {
            return neosyntezClient.GetApiClient(baseUrl).GetP3DbLicense(CancellationToken.None);
        }

        public Task<Plugin3dOptions> GetPluginSettings()
        {
            return neosyntezClient.GetApiClient(baseUrl).GetP3DBPluginOptions(CancellationToken.None);
        }
    }
}
