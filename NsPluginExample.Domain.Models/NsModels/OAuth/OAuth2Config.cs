using System.Collections.Generic;

namespace NsPluginExample.Domain.Models.NsModels.OAuth
{
    public class OAuth2Config
    {
        /// <inheritdoc />
        public string AuthorizationEndpoint { get; set; }

        /// <inheritdoc />
        public string TokenEndpoint { get; set; }

        /// <inheritdoc />
        public string RevocationEndpoint { get; set; }

        /// <inheritdoc />
        public string UserInfoEndpoint { get; set; }

        /// <inheritdoc />
        public string CallbackUri { get; set; }

        /// <inheritdoc />
        public string ClientId { get; set; }

        /// <inheritdoc />
        public string ClientSecret { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        /// <inheritdoc />
        public IList<string> Scope { get; set; }
    }
}
