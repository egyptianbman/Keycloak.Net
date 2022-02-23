using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// The code challenge method for PKCE is used. If not specified, keycloak does not applies PKCE to a client unless 
    /// the client sends an authorization request with appropriate code challenge and code exchange method.
    /// </summary>
    /// <remarks>
    /// See https://tools.ietf.org/html/rfc7636#section-6.2.2.
    /// </remarks>
    [JsonConverter(typeof(JsonEnumConverter<PkceCodeChallengeMethod>))]
    public enum PkceCodeChallengeMethod
    {
        /// <summary>
        /// The plain transformation is for compatibility with existing deployments and for constrained environments that can't use the S256 transformation.
        /// </summary>
        [Description("plain")]
        Plain = 0,

        /// <summary>
        /// If the client is capable of using "S256", it MUST use "S256", as "S256" is Mandatory To Implement (MTI) on the server. 
        /// Clients are permitted to use "plain" only if they cannot support "S256" for some technical reason and know via out-of-band configuration that the server supports "plain".
        /// </summary>
        [Description("S256")]
        S256 = 1
    }
}
