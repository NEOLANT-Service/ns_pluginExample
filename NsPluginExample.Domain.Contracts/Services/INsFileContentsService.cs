using NsApiModels;
using System;
using System.Threading.Tasks;

namespace NsPluginExample.Domain.Contracts.Services
{
    public interface INsFileContentsService
    {
        Task<ContentValue> GetContent(Guid id);
    }
}
