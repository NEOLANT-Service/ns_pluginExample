using NsPluginExample.Models.Configuration;

namespace NsPluginExample.Services
{
    public class AppConfigurationService : IAppConfigurationService
    {
        public AppConfigurationService()
        {

        }

        public AppConfigurationService(AppConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AppConfiguration Configuration { get; set; }
    }
}
