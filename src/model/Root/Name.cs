using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonEnumConverter<Name>))]
    public enum Name
    {
        [Description("base")]
        Base,

        [Description("keycloak")]
        Keycloak,

        [Description("rh-sso")]
        RhSso
    }
}