using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonEnumConverter<JsonTypeLabel>))]
    public enum JsonTypeLabel
    {
        [Description("boolean")]
        Boolean,

        [Description("clientlist")]
        ClientList,

        [Description("file")]
        File,

        [Description("list")]
        List,

        [Description("multivaluedlist")]
        MultivaluedList,

        [Description("multivaluedstring")]
        MultivaluedString,

        [Description("password")]
        Password,

        [Description("role")]
        Role,

        [Description("script")]
        Script,

        [Description("string")]
        String,

        [Description("text")]
        Text
    }
}