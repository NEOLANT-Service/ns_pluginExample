using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NsApiModels;

namespace NsPluginExample.Extensions
{
    public static class ControllerBaseExtensions
    {
        /// <summary>
        /// Сформирует ответ-файл, для передачи его клиенту
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="content">Описание содержимого файла</param>
        /// <param name="disposition"></param>
        /// <param name="noCache"></param>
        /// <returns></returns>
        public static FileStreamResult BuildFileResponse(this ControllerBase controller, ContentValue content, string disposition = "attachment", bool noCache = true)
        {
            var headers = controller.Response.GetTypedHeaders();
            headers.ContentDisposition = new ContentDispositionHeaderValue(disposition) { FileName = content.Name, FileNameStar = content.Name };
            headers.ContentLength = content.Size;
            if (!noCache) headers.CacheControl = new CacheControlHeaderValue { NoStore = true, Private = true };

            return controller.File(content.Stream, content.MediaType ?? MediaTypeNames.Application.Octet);
        }
    }
}
