namespace NsPluginExample.Models.Configuration
{
    public class NeosiyntezClientConfig
    {
        /// <summary>
        /// Адрес экземпляра НЕОСИНТЕЗ
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Тип аутентификации OAuth2
        /// </summary>
        public AuthType AuthType { get; set; }

        /// <summary>
        /// Настройки аутентификации
        /// </summary>
        public AuthConfig Auth { get; set; }

        public NeosiyntezClientConfig Clone()
        {
            return new NeosiyntezClientConfig()
            {
                AuthType = AuthType,
                Instance = string.Copy(Instance),
                Auth = Auth.Clone()
            };
        }
    }
}
