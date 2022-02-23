using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonEnumConverter<ConfigType>))]
    public enum ConfigType
    {
        [Description("int")]
        Int,

        [Description("string")]
        String
    }
}