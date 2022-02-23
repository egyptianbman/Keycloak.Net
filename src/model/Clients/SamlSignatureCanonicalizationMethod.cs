using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Canonicalization Method for XML signatures.
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<SamlSignatureCanonicalizationMethod>))]
    public enum SamlSignatureCanonicalizationMethod
    {
        [Description("")]
        None,

        [Description("http://www.w3.org/2001/10/xml-exc-c14n#")]
        Exclusive,

        [Description("http://www.w3.org/2001/10/xml-exc-c14n#WithComments")]
        ExclusiveWithComments,

        [Description("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")]
        Inclusive,

        [Description("http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments")]
        InclusiveWithComments,
    }
}