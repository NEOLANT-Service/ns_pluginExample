using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Extensions;

namespace NsPluginExample.Controllers
{
    [Route("api/[controller]")]
    public class ModelsController : ControllerBase
    {
        private readonly INsModelsService modelsService;

        public ModelsController(INsModelsService modelsService)
        {
            this.modelsService = modelsService;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetModels(long id)
        {
            return Ok(await modelsService.GetModelsAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetModels()
        {
            return Ok(await modelsService.GetModelsAsync());
        }


        [HttpGet("{id:long}/content")]
        public async Task<IActionResult> GetModelContent([FromRoute] long id)
        {
            return Ok(await modelsService.GetModelContentAsync(id));
        }

        [HttpGet("/api/content/{contentId:guid}")]
        public async Task<IActionResult> GetP3DBFile([FromRoute] Guid contentId)
        {
            var content = await modelsService.GetP3DBFile(contentId);
            return content != null ? this.BuildFileResponse(content) : (IActionResult)NotFound();
        }
    }
}
