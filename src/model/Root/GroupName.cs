using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonEnumConverter<GroupName>))]
    public enum GroupName
    {
        [Description("social")]
        Social,

        [Description("userdefined")]
        UserDefined
    }
}