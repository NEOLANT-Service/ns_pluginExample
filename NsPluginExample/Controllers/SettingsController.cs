using Microsoft.AspNetCore.Mvc;
using NsPluginExample.Models.Configuration;
using NsPluginExample.Services;
using System;

namespace NsPluginExample.Controllers
{
    [Route("api/settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IAppConfigurationService configurationService;

        public SettingsController(IAppConfigurationService configurationService)
        {
            this.configurationService = configurationService ?? throw new System.ArgumentNullException(nameof(configurationService));
        }

        [ProducesResponseType(200, Type = typeof(AppConfiguration))]
        public IActionResult Get()
        {
            var config = (AppConfiguration)configurationService.Configuration.Clone();
            switch (config.NeosyntezClient.AuthType)
            {
                case AuthType.AccessCode:
                    config.NeosyntezClient.Auth = null;
                    config.NeosyntezClient.Instance = string.Empty;
                    return Ok(config);
                case AuthType.ImplicitFlow:
                case AuthType.AccessToken:
                    config.NeosyntezClient.Auth.Password = null;
                    config.NeosyntezClient.Auth.Secret = null;
                    config.NeosyntezClient.Auth.UserName = null;
                    return Ok(config);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
