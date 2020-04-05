using System;

namespace NsPluginExample.Models.Configuration
{
    /// <summary>
    /// Тип аутентификации 
    /// </summary>
    public enum AuthType
    {
        [Obsolete]
        None = 0,
        AccessCode,
        ImplicitFlow,
        AccessToken
    }
}
