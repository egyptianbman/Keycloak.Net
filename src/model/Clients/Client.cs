using System.Collections.Generic;
using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_clientrepresentation
    /// </summary>
    public class Client
    {
        [JsonProperty("access")]
        public ClientAccess? Access { get; set; }

        /// <summary>
        /// URL to the admin interface of the client. Set this if the client supports the adapter REST API. This REST API allows the auth server to push revocation policies and other administrative tasks.
        /// Usually this is set to the base URL of the client.
        /// </summary>
        [JsonProperty("adminUrl")]
        public string? AdminUrl { get; set; }

        /// <summary>
        /// Always list this client in the Account Console, even if the user does not have an active session.
        /// </summary>
        [JsonProperty("alwaysDisplayInConsole")]
        public bool AlwaysDisplayInConsole { get; set; }

        /// <inheritdoc cref="ClientAttributes"/>
        [JsonProperty("attributes")]
        public ClientAttributes? Attributes { get; set; }

        /// <inheritdoc cref="Clients.AuthenticationFlowBindingOverrides"/>
        [JsonProperty("authenticationFlowBindingOverrides")]
        public AuthenticationFlowBindingOverrides? AuthenticationFlowBindingOverrides { get; set; }

        /// <summary>
        /// Enable/Disable <a href="https://www.keycloak.org/docs/latest/server_admin/index.html#_fine_grain_permissions">fine-grained authorization support</a> for a client.
        /// </summary>
        [JsonProperty("authorizationServicesEnabled")]
        public bool AuthorizationServicesEnabled { get; set; }

        /// <summary>
        /// The client's authorization service resource server
        /// </summary>
        [JsonProperty("authorizationSettings")]
        public ResourceServer? AuthorizationSettings { get; set; }

        /// <summary>
        /// Default URL to use when the auth server needs to redirect or link back to the client.
        /// </summary>
        [JsonProperty("baseUrl")]
        public string? BaseUrl { get; set; }

        /// <summary>
        /// 'Bearer-only' clients are web services that never initiate a login.
        /// </summary>
        [JsonProperty("bearerOnly")]
        public bool BearerOnly { get; set; }

        /// <inheritdoc cref="Clients.ClientAuthenticatorType"/>
        [JsonProperty("clientAuthenticatorType")]
        public ClientAuthenticatorType? ClientAuthenticatorType { get; set; }

        /// <summary>
        /// Specifies ID referenced in URI and tokens. For example 'my-client'. For SAML this is also the expected issuer value from authn requests.
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// If enabled, users have to consent to client access.
        /// </summary>
        [JsonProperty("consentRequired")]
        public bool ConsentRequired { get; set; }

        /// <summary>
        /// Default client scopes are always applied when issuing tokens for this client. Protocol mappers and role scope mappings are always applied regardless of value of used scope parameter in OIDC Authorization request.
        /// </summary>
        [JsonProperty("defaultClientScopes")]
        public IEnumerable<string>? DefaultClientScopes { get; set; }

        /// <summary>
        /// Specifies description of the client. For example 'My Client for TimeSheets'. Supports keys for localized values as well. For example: ${my_client_description}
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// This enables support for Direct Access Grants, which means that client has access to username/password of user and exchange it directly with Keycloak server for access token.
        /// In terms of OAuth2 specification, this enables support of 'Resource Owner Password Credentials Grant' for this client.
        /// </summary>
        [JsonProperty("directAccessGrantsEnabled")]
        public bool DirectAccessGrantsEnabled { get; set; }

        /// <summary>
        /// Disabled clients cannot initiate a login or have obtain access tokens.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// When true, logout requires a browser redirect to client. When false, server performs a background invocation for logout.
        /// </summary>
        [JsonProperty("frontchannelLogout")]
        public bool FrontChannelLogout { get; set; }

        /// <summary>
        /// Allows you to disable all restrictions.
        /// </summary>
        [JsonProperty("fullScopeAllowed")]
        public bool FullScopeAllowed { get; set; }

        /// <summary>
        /// Specifies ID referenced in URI and tokens. For example 'my-client'. For SAML this is also the expected issuer value from authn requests
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// This enables support for OpenID Connect redirect based authentication without authorization code.
        /// In terms of OpenID Connect or OAuth2 specifications, this enables support of 'Implicit Flow' for this client.
        /// </summary>
        [JsonProperty("implicitFlowEnabled")]
        public bool ImplicitFlowEnabled { get; set; }

        /// <summary>
        /// Specifies display name of the client. For example 'My Client'. Supports keys for localized values as well. For example: ${my_client}
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Interval to specify max time for registered clients cluster nodes to re-register. If cluster node will not send re-registration request to Keycloak within this time, it will be unregistered from Keycloak
        /// </summary>
        [JsonProperty("nodeReRegistrationTimeout")]
        public int? NodeReregistrationTimeout { get; set; }

        /// <summary>
        /// Revoke any tokens issued before this date for this client.
        /// </summary>
        [JsonProperty("notBefore")]
        public int? NotBefore { get; set; }

        /// <summary>
        /// This enables support for OAuth 2.0 Device Authorization Grant, which means that client is an application on device that has limited input capabilities or lack a suitable browser.
        /// </summary>
        [JsonProperty("oauth2DeviceAuthorizationGrantEnabled")]
        public bool? Oauth2DeviceAuthorizationGrantEnabled { get; set; }

        /// <summary>
        /// Optional client scopes are applied when issuing tokens for this client, however just in case when they are requested by scope parameter in OIDC Authorization request.
        /// </summary>
        [JsonProperty("optionalClientScopes")]
        public IEnumerable<string>? OptionalClientScopes { get; set; }

        [JsonProperty("origin")]
        public string? Origin { get; set; }

        /// <summary>
        /// Supports the following options:
        /// <list type="bullet">
        /// <item>
        ///     <term>OpenID connect</term>
        ///     <description>Allows Clients to verify the identity of the End-User based on the authentication performed by an Authorization Server.</description>
        /// </item>
        /// <item>
        ///     <term>SAML</term>
        ///     <description>Enables web-based authentication and authorization scenarios including cross-domain single sign-on (SSO) and uses security tokens containing assertions to pass information.</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty("protocol")]
        public string? Protocol { get; set; }

        /// <inheritdoc cref="ClientProtocolMapper"/>
        [JsonProperty("protocolMappers")]
        public IEnumerable<ClientProtocolMapper>? ProtocolMappers { get; set; }

        /// <summary>
        /// If true, this client do not require a secret;<br/>
        /// If false, this clients require a secret to initiate login protocol.
        /// </summary>
        [JsonProperty("publicClient")]
        public bool PublicClient { get; set; }

        /// <summary>
        /// Valid URI pattern a browser can redirect to after a successful login or logout. Simple wildcards are allowed such as 'http://example.com/*'.
        /// Relative path can be specified too such as /my/relative/path/*. Relative paths are relative to the client root URL, or if none is specified the auth server root URL is used.<br/><br/>
        /// For SAML, you must set valid URI patterns if you are relying on the consumer service URL embedded with the login request.
        /// </summary>
        [JsonProperty("redirectUris")]
        public IEnumerable<string>? RedirectUris { get; set; }

        /// <summary>
        /// Manually register cluster node. This is usually not needed as cluster node should be registered automatically by keycloak adapter.
        /// </summary>
        [JsonProperty("registeredNodes")]
        public IDictionary<string, object>? RegisteredNodes { get; set; }

        /// <summary>
        /// The registration access token provides access for clients to the client registration service.
        /// </summary>
        [JsonProperty("registrationAccessToken")]
        public string? RegistrationAccessToken { get; set; }

        /// <summary>
        /// Root URL appended to relative URLs.
        /// </summary>
        [JsonProperty("rootUrl")]
        public string? RootUrl { get; set; }

        /// <summary>
        /// The secret used for client credentials flow.
        /// </summary>
        [JsonProperty("secret")]
        public string? Secret { get; set; }

        /// <summary>
        /// Allows you to authenticate this client to Keycloak and retrieve access token dedicated to this client.
        /// In terms of OAuth2 specification, this enables support of 'Client Credentials Grant' for this client.
        /// </summary>
        [JsonProperty("serviceAccountsEnabled")]
        public bool ServiceAccountsEnabled { get; set; }

        /// <summary>
        /// This enables standard OpenID Connect redirect based authentication with authorization code.
        /// In terms of OpenID Connect or OAuth2 specifications, this enables support of 'Authorization Code Flow' for this client.
        /// </summary>
        [JsonProperty("standardFlowEnabled")]
        public bool StandardFlowEnabled { get; set; }

        [JsonProperty("surrogateAuthRequired")]
        public bool SurrogateAuthRequired { get; set; }

        /// <summary>
        /// Allowed CORS origins. To permit all origins of Valid Redirect URIs, add '+'. This does not include the '*' wildcard though. To permit all origins, explicitly add '*'.
        /// </summary>
        [JsonProperty("webOrigins")]
        public IEnumerable<string>? WebOrigins { get; set; }

    }
}
