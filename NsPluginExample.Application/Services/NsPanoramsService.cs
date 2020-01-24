using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NsApiModels;
using NsPluginExample.Domain.Contracts.Services;

namespace NsPluginExample.Application.Services
{
    public class NsPanoramsService : INsPanoramsService
    {
        private readonly INeosyntezClient neosyntezClient;
        private readonly string baseUrl;

        public NsPanoramsService(
            INeosyntezClient neosyntezClient,
            string baseUrl
            )
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("message", nameof(baseUrl));
            }

            this.neosyntezClient = neosyntezClient ?? throw new ArgumentNullException(nameof(neosyntezClient));
            this.baseUrl = baseUrl;
        }

        public Task<ICollection<PanoTour>> GetAllAsync()
        {
            return neosyntezClient.GetApiClient(baseUrl).GetToursAsync();
        }

        public async Task<ContentValue> GetContenAsync(Guid id, string url)
        {
            var httpContent = await neosyntezClient.GetApiClient(baseUrl).GetTourContent(id, url, cancellationToken: CancellationToken.None);
            return httpContent;
        }

        public Task<PanoTourInfo> GetInfoAsync(Guid id)
        {
            return neosyntezClient.GetApiClient(baseUrl).GetTourAsync(id);
        }
    }
}
