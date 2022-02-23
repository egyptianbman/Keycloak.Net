using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.IdentityProviders
{
    [JsonConverter(typeof(JsonEnumConverter<IdentityProviderMapperType>))]
    public enum IdentityProviderMapperType
    {
        [Description("hardcoded-user-session-attribute-idp-mapper")]
        HardcodedUserSessionAttribute,

        [Description("oidc-hardcoded-role-idp-mapper")]
        HardcodedRole,

        [Description("facebook-user-attribute-mapper")]
        AttributeImporter,

        [Description("hardcoded-attribute-idp-mapper")]
        HardcodedAttribute,

        [Description("oidc-username-idp-mapper")]
        UsernameTemplateImporter
    }
}
