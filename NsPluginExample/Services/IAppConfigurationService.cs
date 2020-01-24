using NsPluginExample.Models.Configuration;

namespace NsPluginExample.Services
{
    public interface IAppConfigurationService
    {
        AppConfiguration Configuration { get; set; }
    }
}
