using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.RealmsAdmin
{
    [JsonConverter(typeof(JsonEnumConverter<Policies>))]
    public enum Policies
    {
        [Description("SKIP")]
        Skip,

        [Description("OVERWRITE")]
        Overwrite,

        [Description("FAIL")]
        Fail
    }
}
