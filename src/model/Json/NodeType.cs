using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Json
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_jsonnode
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<NodeType>))]
    public enum NodeType
    {
        [Description("ARRAY")]
        Array,

        [Description("BINARY")]
        Binary,

        [Description("BOOLEAN")]
        Boolean,

        [Description("MISSING")]
        Missing,

        [Description("NULL")]
        Null,

        [Description("NUMBER")]
        Number,

        [Description("OBJECT")]
        Object,

        [Description("POJO")]
        Pojo,

        [Description("STRING")]
        String
    }
}
