using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Signed SAML documents contain identification of signing key in KeyName element.
    /// </summary>
    [Description("SAML Signature Key Name")]
    [JsonConverter(typeof(JsonEnumConverter<SamlSignatureKeyName>))]
    public enum SamlSignatureKeyName
    {
        /// <summary>
        /// For others check and use <c>NONE</c> if no other option works.
        /// </summary>
        [Description("NONE")]
        None,

        /// <summary>
        /// For Keycloak / RH-SSO counterparty, use <c>KEY_ID</c>.
        /// </summary>
        [Description("KEY_ID")]
        KeyId,

        /// <summary>
        /// For MS AD FS, use <c>CERT_SUBJECT</c>.
        /// </summary>
        [Description("CERT_SUB")]
        CertSub
    }
}
