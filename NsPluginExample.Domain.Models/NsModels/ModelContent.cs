using System;

namespace NsPluginExample.Domain.Models.NsModels
{
    public class ModelContent
    {
        public string MediaType { get; set; }
        
        /// <summary>
        /// расширение файла
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Хэш содержимого файла
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Версия
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Размер файла
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Идентификатор файла
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }
    }
}
