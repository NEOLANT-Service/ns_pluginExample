using NsApiModels;
using NsPluginExample.Domain.Contracts.Services;
using System;
using System.Threading.Tasks;

namespace NsPluginExample.Application.Services
{
    public class NsFileContentsService : INsFileContentsService
    {
        private readonly INeosyntezClient neosyntezClient;
        private readonly string baseUrl;

        public NsFileContentsService(
            INeosyntezClient neosyntezClient,
            string baseUrl)
        {
            this.neosyntezClient = neosyntezClient ?? throw new ArgumentNullException(nameof(neosyntezClient));
            this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }


        public Task<ContentValue> GetContent(Guid id)
        {
            return neosyntezClient.GetApiClient(baseUrl).GetContentAsync(id);
        }
    }
}
