using System;
using Newtonsoft.Json;

namespace NsPluginExample.Domain.Models.NsModels.OAuth
{
    /// <summary>
    /// Токен безопасности
    /// </summary>
    public class OAuth2Token
    {
        /// <summary>
        /// Время создания токена
        /// </summary>
        private readonly DateTime createTime;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public OAuth2Token()
        {
            createTime = DateTime.Now;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="accessToken">Токен безопасности</param>
        /// <param name="refreshToken">Токен обновления токена безопасности</param>
        /// <param name="type">Тип токена</param>
        public OAuth2Token(string accessToken, string refreshToken, string type)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("Access token is empty", nameof(accessToken));
            }

            createTime = DateTime.Now;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Type = type;
        }

        /// <summary>
        /// Идентификатор 
        /// </summary>
        /// <remarks>
        /// Можно было бы использовать первичным ключом AccessToken, но миграции ограничивают длину кластерного индекса 450 символами, в которые токен не укладывается
        /// </remarks>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Токен
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; protected set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; protected set; }

        [JsonProperty("token_type")]
        public string Type { get; protected set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; protected set; }

        public bool IsExpired => DateTime.UtcNow.CompareTo(createTime.AddSeconds(ExpiresIn)) > 0;
    }
}
