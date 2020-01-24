using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NsApiModels;

namespace NsPluginExample.Domain.Contracts.Services
{
    /// <summary>
    /// Сервис для работы с моделфями НЕОСИНТЕЗ
    /// </summary>
    public interface INsModelsService
    {
        Task<ICollection<ContentValue>> GetModelContentAsync(long id);

        /// <summary>
        /// Вернет лицензия для P3DB
        /// </summary>
        /// <returns></returns>
        Task<ContentValue> GetP3DBLicence();

        /// <summary>
        /// Вернет список дочерних моделей узла для <paramref name="id"/>
        /// </summary>
        /// <param name="id">Идентификатор модели</param>
        /// <returns></returns>
        Task<ICollection<NodeNg>> GetModelsAsync(long? id=null);

        /// <summary>
        /// Вернет содержимое P3DB-файла
        /// </summary>
        /// <param name="id">Идентфиикаор модели</param>
        /// <param name="contentId">Идентификатор файла</param>
        /// <returns></returns>
        Task<ContentValue> GetP3DBFile(long id, Guid contentId);

        /// <summary>
        /// Вернет настройик для плагина
        /// </summary>
        /// <returns></returns>
        Task<Plugin3dOptions> GetPluginSettings();
    }
}
