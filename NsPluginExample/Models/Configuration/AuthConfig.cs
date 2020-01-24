namespace NsPluginExample.Models.Configuration
{
    public class AuthConfig
    {
        /// <summary>
        /// Идентификатор приложения-клиента
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Секрет приложения-клиента
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль поьзователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Тип хранилище, используемый для хранения токена безопасности
        /// </summary>
        public TokenStorageType TokenStorage { get; set; } = TokenStorageType.Memory;
    }
}
