using System;

namespace NsPluginExample.Models.Configuration
{
    public class AppConfiguration
    {
        public NeosiyntezClientConfig NeosyntezClient { get; set; }

        public AppConfiguration Clone()
        {
            return new AppConfiguration
            {
                NeosyntezClient = NeosyntezClient.Clone()
            };
        }
    }
}
