using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.IdentityProviders
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/broker/saml/mappers/UsernameTemplateMapper.Target.html
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<UsernameTemplateMapperTarget>))]
    public enum UsernameTemplateMapperTarget
    {
        [Description("LOCAL")]
        Local,

        [Description("BROKER_ID")]
        BrokerId,

        [Description("BROKER_USERNAME")]
        BrokerUsername
    }
}
