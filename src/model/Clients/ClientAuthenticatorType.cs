using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Client Authenticator used for authentication of this client against Keycloak server.
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<ClientAuthenticatorType>))]
    public enum ClientAuthenticatorType
    {
        /// <summary>
        /// Signed Jwt
        /// </summary>
        [Description("client-jwt")]
        ClientJwt = 0,

        /// <summary>
        /// Client Id and Secret
        /// </summary>
        [Description("client-secret")]
        ClientSecret = 1,

        /// <summary>
        /// X509 Certificate
        /// </summary>
        [Description("client-x509")]
        ClientX509 = 2,

        /// <summary>
        /// Signed Jwt with Client Secret
        /// </summary>
        [Description("client-secret-jwt")]
        ClientSecretJwt = 3
    }
}
