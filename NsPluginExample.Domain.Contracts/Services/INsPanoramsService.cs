using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NsApiModels;

namespace NsPluginExample.Domain.Contracts.Services
{
    public interface INsPanoramsService
    {
        Task<ICollection<PanoTour>> GetAllAsync();

        Task<PanoTourInfo> GetInfoAsync(Guid id);

        Task<ContentValue> GetContenAsync(Guid id, string url);
    }
}
