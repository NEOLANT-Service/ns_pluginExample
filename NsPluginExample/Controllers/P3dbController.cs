using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Extensions;
using NsPluginExample.Services;

namespace NsPluginExample.Controllers
{
    [Route("api/3d")]
    [ApiController]
    public class P3dbController : ControllerBase
    {
        private readonly INsModelsService modelsService;
        private readonly IAppConfigurationService configurationService;

        public P3dbController(
            INsModelsService modelsService,
            IAppConfigurationService configurationService
            )
        {
            this.modelsService = modelsService;
            this.configurationService = configurationService;
        }

        /// <summary>
        /// Вернет лицензию для плагина
        /// </summary>
        /// <returns></returns>
        [HttpGet("licence/.lic")]
        public async Task<IActionResult> GetLicence()
        {
            var content = await modelsService.GetP3DBLicence();
            return content != null ? this.BuildFileResponse(content, "inline") : (IActionResult)NotFound();
        }

        /// <summary>
        /// Вернет настройки для плагина
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/settings/plugin3d")]
        public async Task<IActionResult> GetSettings()
        {
            return Ok(await modelsService.GetPluginSettings());
        }

        /// <summary>
        /// Перенаправит на адресс скачивания плагина с экземпляра НЕОСИНТЕЗ
        /// </summary>
        /// <returns></returns>
        [HttpGet("wio3d_setup.exe")]
        public async Task<IActionResult> PluginDownload()
        {
            var instance = configurationService.Configuration.NeosyntezClient.Instance;
            return Redirect($"{instance}/3d/wio3d_setup.exe");
        }
    }
}