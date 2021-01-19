using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Extensions;
using NsPluginExample.Services;

namespace NsPluginExample.Controllers
{
    /// <summary>
    /// Контроллер для работы с панорамами
    /// </summary>
    [Route("api/pano")]
    [ApiController]
    public class PanoramsController : ControllerBase
    {
        private readonly INsPanoramsService panoramsService;
        private readonly IAppConfigurationService appConfigurationService;

        public PanoramsController(INsPanoramsService panoramsService, IAppConfigurationService appConfigurationService)
        {
            this.panoramsService = panoramsService;
            this.appConfigurationService = appConfigurationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAync()
        {
            return Ok(await panoramsService.GetAllAsync());
        }

        [HttpGet("{panoramaId:guid}")]
        public async Task<IActionResult> GetAsync(Guid panoramaId)
        {
            return Ok(await panoramsService.GetInfoAsync(panoramaId));
        }

        [HttpGet("{panoramaId:guid}/content/{*url}")]
        public async Task<IActionResult> GetContent(Guid panoramaId, string url)
        {
            var content = await panoramsService.GetContenAsync(panoramaId, url);

            return content != null ? EnsureConfig(this.BuildFileResponse(content, "inline")) : (IActionResult)NotFound();

            FileStreamResult EnsureConfig(FileStreamResult r)
            {
                if (r.ContentType == "text/xml")
                {
                    if (Response.Headers.ContainsKey(HeaderNames.CacheControl)) Response.Headers.Remove(HeaderNames.CacheControl);
                    Response.Headers.Add(HeaderNames.CacheControl, "no-cache, no-store");
                }
                return r;
            }
        }
    }
}