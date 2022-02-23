using Newtonsoft.Json;

namespace Keycloak.Net.Model.Json
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_jsonnode
    /// </summary>
    public class JsonNode
    {
        [JsonProperty("array")]
        public bool? Array { get; set; }

        [JsonProperty("bigDecimal")]
        public bool? BigDecimal { get; set; }

        [JsonProperty("bigInteger")]
        public bool? BigInteger { get; set; }

        [JsonProperty("binary")]
        public bool? Binary { get; set; }

        [JsonProperty("boolean")]
        public bool? Boolean { get; set; }

        [JsonProperty("containerNode")]
        public bool? ContainerNode { get; set; }

        [JsonProperty("double")]
        public bool? Double { get; set; }

        [JsonProperty("empty")]
        public bool? Empty { get; set; }

        [JsonProperty("float")]
        public bool? Float { get; set; }

        [JsonProperty("floatingPointNumber")]
        public bool? FloatingPointNumber { get; set; }

        [JsonProperty("int")]
        public bool? Int { get; set; }

        [JsonProperty("integralNumber")]
        public bool? IntegralNumber { get; set; }

        [JsonProperty("long")]
        public bool? Long { get; set; }
        
        [JsonProperty("missingNode")]
        public bool? MissingNode { get; set; }

        /// <inheritdoc cref="Json.NodeType"/>
        [JsonProperty("nodeType")]
        public NodeType? NodeType { get; set; }
        
        [JsonProperty("null")]
        public bool? Null { get; set; }
        
        [JsonProperty("number")]
        public bool? Number { get; set; }
        
        [JsonProperty("object")]
        public bool? Object { get; set; }
        
        [JsonProperty("pojo")]
        public bool? Pojo { get; set; }
        
        [JsonProperty("short")]
        public bool? Short { get; set; }
        
        [JsonProperty("textual")]
        public bool? Textual { get; set; }
        
        [JsonProperty("valueNode")]
        public bool? ValueNode { get; set; }
    }
}
