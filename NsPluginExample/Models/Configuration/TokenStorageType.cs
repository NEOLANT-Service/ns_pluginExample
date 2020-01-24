namespace NsPluginExample.Models.Configuration
{
    /// <summary>
    /// Тип хранилища токена безопасности
    /// </summary>
    public enum TokenStorageType
    {
        /// <summary>
        /// Токен хранится в памяти
        /// </summary>
        Memory=0,

        /// <summary>
        /// Токен хранится в БД
        /// </summary>
        Database=1
    }
}
