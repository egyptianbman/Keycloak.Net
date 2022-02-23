using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonEnumConverter<Protocol>))]
    public enum Protocol
    {
        [Description("dockerv2")]
        DockerV2,

        [Description("openid-connect")]
        OpenIdConnect,

        [Description("Saml")]
        Saml
    }
}