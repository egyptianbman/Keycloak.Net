using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonEnumConverter<Locale>))]
    public enum Locale
    {
        [Description("en")]
        En
    }
}