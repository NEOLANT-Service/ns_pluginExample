namespace NsPluginExample.Models.Configuration
{
    public class NeosiyntezClientConfig
    {
        /// <summary>
        /// Адрес экземпляра НЕОСИНТЕЗ
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Настройки аутентификации
        /// </summary>
        public AuthConfig Auth { get; set; }
    }
}
