using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.IdentityProviders
{
    [JsonConverter(typeof(JsonEnumConverter<IdentityProviderSyncMode>))]
    public enum IdentityProviderSyncMode
    {
        /// <summary>
        /// To use the sync mode defined in the identity provider for this mapper.
        /// </summary>
        [Description("INHERIT")]
        Inherit,

        /// <summary>
        /// To keep the behaviour before this option was introduced.
        /// </summary>
        [Description("LEGACY")]
        Legacy,

        /// <summary>
        /// To only import the user once during first login of the user with this identity provider.
        /// </summary>
        [Description("IMPORT")]
        Import,

        /// <summary>
        /// To always update the user during every login with this identity provider.
        /// </summary>
        [Description("FORCE")]
        Force
    }
}
