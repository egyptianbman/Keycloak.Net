using System;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Additional attributes for <see cref="Client"/>.
    /// </summary>
    /// <remarks>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/github' />/services/src/main/java/org/keycloak/protocol/oidc/OIDCConfigAttributes.java.
    /// </remarks>
    public class ClientAttributes
    {
        /// <summary>
        /// Max time before an access token is expired. This value is recommended to be short relative to the SSO timeout.
        /// </summary>
        [JsonProperty("access.token.lifespan")]
        public int? AccessTokenLifespan { get; set; }

        /// <summary>
        /// JWA algorithm used for signing access tokens.
        /// </summary>
        [JsonProperty("access.token.signed.response.alg")]
        public string? AccessTokenSignedResponseAlg { get; set; }

        /// <summary>
        /// JWA Algorithm used for key management in encrypting the authorization response when the response mode is jwt.
        /// This option is needed if you want encrypted authorization response. If left empty, the authorization response is just signed, but not encrypted.
        /// </summary>
        [JsonProperty("authorization.encrypted.response.alg")]
        public string? AuthorizationEncryptedResponseAlg { get; set; }

        /// <summary>
        /// JWA Algorithm used for content encryption in encrypting the authorization response when the response mode is jwt.
        /// This option is needed if you want encrypted authorization response. If left empty, the authorization response is just signed, but not encrypted.
        /// </summary>
        [JsonProperty("authorization.encrypted.response.enc")]
        public string? AuthorizationEncryptedResponseEnc { get; set; }

        /// <summary>
        /// JWA algorithm used for signing authorization response tokens when the response mode is jwt.
        /// </summary>
        [JsonProperty("authorization.signed.response.alg")]
        public string? AuthorizationSignedResponseAlg { get; set; }

        /// <summary>
        /// URL that will cause the client to log itself out when a logout request is sent to this realm (via end_session_endpoint).
        /// If omitted, no logout request will be sent to the client is this case.
        /// </summary>
        [JsonProperty("backchannel.logout.url")]
        public string? BackchannelLogoutUrl { get; set; }

        /// <summary>
        /// Specifying whether a sid (session ID) Claim is included in the Logout Token when the Backchannel Logout URL is used.
        /// </summary>
        [JsonProperty("backchannel.logout.session.required")]
        public bool? BackchannelLogoutSessionRequired { get; set; }

        /// <summary>
        /// Specifying whether a "revoke_offline_access" event is included in the Logout Token when the Backchannel Logout URL is used.
        /// Keycloak will revoke offline sessions when receiving a Logout Token with this event.
        /// </summary>
        [JsonProperty("backchannel.logout.revoke.offline.tokens")]
        public bool? BackchannelLogoutRevokeOfflineTokens { get; set; }

        /// <summary>
        /// If this is on, a refresh_token will be created and added to the token response if the client_credentials grant is used.
        /// The OAuth 2.0 RFC6749 Section 4.4.3 states that a refresh_token should not be generated when client_credentials grant is used.
        /// If this is off then no refresh_token will be generated and the associated user session will be removed.
        /// </summary>
        [JsonProperty("client_credentials.use_refresh_token")]
        public bool? ClientCredentialsUseRefreshToken { get; set; }

        /// <summary>
        /// Time a client offline session is allowed to be idle before it expires. Offline tokens are invalidated when a client offline session is expired. If not set it uses the Offline Session Idle value.
        /// </summary>
        [JsonProperty("client.offline.session.idle.timeout")]
        public int? ClientOfflineSessionIdleTimeout { get; set; }

        /// <summary>
        /// Max time before a client offline session is expired. Offline tokens are invalidated when a client offline session is expired. If not set, it uses the Offline Session Max value.
        /// </summary>
        [JsonProperty("client.offline.session.max.lifespan")]
        public int? ClientOfflineSessionMaxLifespan { get; set; }

        /// <summary>
        /// Time a client session is allowed to be idle before it expires. Tokens are invalidated when a client session is expired. If not set it uses the standard SSO Session Idle value.
        /// </summary>
        [JsonProperty("client.session.idle.timeout")]
        public int? ClientSessionIdleTimeout { get; set; }

        /// <summary>
        /// Max time before a client session is expired. Tokens are invalidated when a client session is expired. If not set, it uses the standard SSO Session Max value.
        /// </summary>
        [JsonProperty("client.session.max.lifespan")]
        public int? ClientSessionMaxLifespan { get; set; }

        /// <summary>
        /// If enabled, users have to consent to client access.
        /// </summary>
        [JsonProperty("display.on.consent.screen")]
        public bool? DisplayOnConsentScreen { get; set; }

        /// <summary>
        /// If this is on, the parameter 'session_state' will not be included in OpenID Connect Authentication Response.
        /// It is useful if your client uses older OIDC / OAuth2 adapter, which does not support 'session_state' parameter.
        /// </summary>
        [JsonProperty("exclude.session.state.from.auth.response")]
        public bool? ExcludeSessionStateFromAuthResponse { get; set; }

        /// <summary>
        /// This makes ID token returned from Authorization Endpoint in OIDC Hybrid flow use as a detached signature defined in FAPI 1.0 Advanced Security Profile.
        /// Therefore, this ID token does not include an authenticated user's information.
        /// </summary>
        [JsonProperty("id.token.as.detached.signature")]
        public bool? IdTokenAsDetachedSignature { get; set; }

        /// <summary>
        /// JWA Algorithm used for key management in encrypting ID tokens. This option is needed if you want encrypted ID tokens. If left empty, ID Tokens are just signed, but not encrypted.
        /// </summary>
        [JsonProperty("id.token.encrypted.response.alg")]
        public string? IdTokenEncryptedResponseAlg { get; set; }

        /// <summary>
        /// JWA Algorithm used for content encryption in encrypting ID tokens. This option is needed just if you want encrypted ID tokens. If left empty, ID Tokens are just signed, but not encrypted.
        /// </summary>
        [JsonProperty("id.token.encrypted.response.enc")]
        public string? IdTokenEncryptedResponseEnc { get; set; }

        /// <summary>
        /// JWA algorithm used for signing ID tokens.
        /// </summary>
        [JsonProperty("id.token.signed.response.alg")]
        public string? IdTokenSignedResponseAlg { get; set; }

        /// <summary>
        /// Select theme for login, OTP, grant, registration, and forgot password pages.
        /// <list type="bullet">
        /// <item>
        ///     <term>base</term>
        ///     <description>The basic design.</description>
        /// </item>
        /// <item>
        ///     <term>keycloak</term>
        ///     <description>Keycloak default design</description>
        /// </item>
        /// <item>
        ///     <term>{custom}</term>
        ///     <description>Use the custom named theme available.</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty("login_theme")] 
        public string? LoginTheme { get; set; }

        /// <summary>
        /// This enables support for OIDC CIBA Grant, which means that the user is authenticated via some external authentication device instead of the user's browser.
        /// </summary>
        [JsonProperty("oidc.ciba.grant.enabled")]
        public bool? OidcCibaGrantEnabled { get; set; }

        /// <summary>
        /// This enables support for OAuth 2.0 Device Authorization Grant, which means that client is an application on device that has limited input capabilities or lack a suitable browser.
        /// </summary>
        [JsonProperty("oauth2.device.authorization.grant.enabled")]
        public bool? Oauth2DeviceAuthorizationGrantEnabled { get; set; }

        [JsonProperty("oauth2.device.polling.interval")]
        public int? Oauth2DevicePollingInterval { get; set; }

        /// <inheritdoc cref="PkceCodeChallengeMethod"/>
        [JsonProperty("pkce.code.challenge.method")]
        public PkceCodeChallengeMethod? PkceCodeChallengeMethod { get; set; }

        /// <inheritdoc cref="Clients.RequestObjectRequired"/>
        [JsonProperty("request.object.required")]
        public RequestObjectRequired? RequestObjectRequired { get; set; }

        /// <summary>
        /// JWE algorithm, which client needs to use when sending OIDC request object specified by 'request' or 'request_uri' parameters. If set to 'any', encryption is optional and any algorithm is allowed.
        /// </summary>
        [JsonProperty("request.object.encryption.alg")]
        public string? RequestObjectEncryptionAlg { get; set; }

        /// <summary>
        /// JWE algorithm, which client needs to use when encrypting the content of the OIDC request object specified by 'request' or 'request_uri' parameters. If set to 'any', any algorithm is allowed.
        /// </summary>
        [JsonProperty("request.object.encryption.enc")]
        public string? RequestObjectEncryptionEnc { get; set; }

        /// <summary>
        /// JWA algorithm, which client needs to use when sending OIDC request object specified by 'request' or 'request_uri' parameters. If set to 'any', Request object can be signed by any algorithm (including 'none' ).
        /// </summary>
        [JsonProperty("request.object.signature.alg")]
        public string? RequestObjectSignatureAlg { get; set; }

        /// <summary>
        /// List of valid URIs, which can be used as values of 'request_uri' parameter during OpenID Connect authentication request. There is support for the same capabilities like for Valid Redirect URIs. For example wildcards or relative paths.
        /// </summary>
        [JsonProperty("request.uris")]
        public Uri[]? RequestUris { get; set; }

        /// <summary>
        /// bool?ean parameter indicating whether the authorization server accepts authorization request data only via the pushed authorization request method.
        /// </summary>
        [JsonProperty("require.pushed.authorization.requests")]
        public bool? RequirePushedAuthorizationRequests { get; set; }

        /// <summary>
        /// Should response messages be returned to the client through the SAML ARTIFACT binding system?
        /// </summary>
        [JsonProperty("saml.artifact.binding")]
        public bool? SamlArtifactBinding { get; set; }

        /// <summary>
        /// URL to send the HTTP ARTIFACT messages to. You can leave this blank if you are using a different binding. This value should be set when forcing ARTIFACT binding together with IdP initiated login.
        /// </summary>
        [JsonProperty("saml_artifact_binding_url")]
        public Uri? SamlArtifactBindingUrl { get; set; }

        /// <summary>
        /// SAML Artifact resolution service for the client. This is the endpoint to which Keycloak will send a SOAP ArtifactResolve message. You can leave this blank if you do not have a URL for this binding.
        /// </summary>
        [JsonProperty("saml_artifact_resolution_service_url")]
        public Uri? SamlArtifactResolutionServiceUrl { get; set; }

        /// <summary>
        /// Lifespan set in the SAML assertion conditions. After that time the assertion will be invalid.
        /// The "SessionNotOnOrAfter" attribute is not modified and continue using the "SSO Session Max" time defined at realm level.
        /// </summary>
        [JsonProperty("saml.assertion.lifespan")]
        public int? SamlAssertionLifespan { get; set; }

        /// <summary>
        /// Should assertions inside SAML documents be signed? This setting is not needed if document is already being signed.
        /// </summary>
        [JsonProperty("saml.assertion.signature")]
        public bool? SamlAssertionSignature { get; set; }

        /// <summary>
        /// SAML POST Binding URL for the client's assertion consumer service (login responses). You can leave this blank if you do not have a URL for this binding.
        /// </summary>
        [JsonProperty("saml_assertion_consumer_url_post")]
        public Uri? SamlAssertionConsumerUrlPost { get; set; }

        /// <summary>
        /// SAML Redirect Binding URL for the client's assertion consumer service (login responses). You can leave this blank if you do not have a URL for this binding.
        /// </summary>
        [JsonProperty("saml_assertion_consumer_url_redirect")]
        public Uri? SamlAssertionConsumerUrlRedirect { get; set; }
        
        /// <summary>
        /// Should a statement specifying the method and timestamp be included in login responses?
        /// </summary>
        [JsonProperty("saml.authnstatement")]
        public bool? SamlAuthnstatement { get; set; }

        /// <summary>
        /// Will the client sign their saml requests and responses? And should they be validated?
        /// </summary>
        [JsonProperty("saml.client.signature")]
        public bool? SamlClientSignature { get; set; }

        /// <summary>
        /// Should SAML assertions be encrypted with client's public key using AES?
        /// </summary>
        [JsonProperty("saml.encrypt")]
        public bool? SamlEncrypt { get; set; }

        /// <summary>
        /// Ignore requested NameID subject format and use admin console configured one.
        /// </summary>
        [JsonProperty("saml_force_name_id_format")]
        public bool? SamlForceNameIdFormat { get; set; }

        /// <summary>
        /// Always use POST binding for responses.
        /// </summary>
        [JsonProperty("saml.force.post.binding")]
        public bool? SamlForcePostBinding { get; set; }

        /// <summary>
        /// URL fragment name to reference client when you want to do IDP Initiated SSO. Leaving this empty will disable IDP Initiated SSO.
        /// The URL you will reference from your browser will be: {server-root}/realms/{realm}/protocol/saml/clients/{client-url-name}
        /// </summary>
        [JsonProperty("saml_idp_initiated_sso_url_name")]
        public string? SamlIdpInitiatedSsoUrlName { get; set; }

        /// <summary>
        /// Relay state you want to send with SAML request when you want to do IDP Initiated SSO.
        /// </summary>
        [JsonProperty("saml_idp_initiated_sso_relay_state")]
        public string? SamlIdpInitiatedSsoRelayState { get; set; }

        [JsonProperty("saml.multivalued.roles")]
        public bool? SamlMultivaluedRoles { get; set; }

        /// <summary>
        /// The name ID format to use for the subject.
        /// </summary>
        [JsonProperty("saml_name_id_format")] 
        public string? SamlNameIdFormat { get; set; }

        /// <summary>
        /// Should a OneTimeUse Condition be included in login responses?
        /// </summary>
        [JsonProperty("saml.onetimeuse.condition")]
        public bool? SamlOnetimeUseCondition { get; set; }

        /// <summary>
        /// Should SAML documents be signed by the realm?
        /// </summary>
        [JsonProperty("saml.server.signature")]
        public bool? SamlServerSignature { get; set; }

        /// <summary>
        /// The signature algorithm to use to sign documents.
        /// </summary>
        [JsonProperty("saml.signature.algorithm")]
        public string? SamlSignatureAlgorithm { get; set; }

        /// <inheritdoc cref="Clients.SamlSignatureCanonicalizationMethod"/>
        [JsonProperty("saml_signature_canonicalization_method")]
        public SamlSignatureCanonicalizationMethod? SamlSignatureCanonicalizationMethod { get; set; }

        /// <summary>
        /// When signing SAML documents in REDIRECT binding for SP that is secured by Keycloak adapter, should the ID of the signing key be included in SAML protocol message in 'Extensions' element?
        /// This optimizes validation of the signature as the validating party uses a single key instead of trying every known key for validation.
        /// </summary>
        [JsonProperty("saml.server.signature.keyinfo.ext")]
        public bool? SamlServerSignatureKeyInfoExt { get; set; }

        /// <inheritdoc cref="Clients.SamlSignatureKeyName"/>
        [JsonProperty("saml.server.signature.keyinfo.xmlSigKeyInfoKeyNameTransformer")]
        public SamlSignatureKeyName? SamlServerSignatureKeyInfoXmlSigKeyInfoKeyNameTransformer { get; set; }

        /// <summary>
        /// SAML POST Binding URL for the client's single logout service. You can leave this blank if you are using a different binding.
        /// </summary>
        [JsonProperty("saml_single_logout_service_url_post")]
        public Uri? SamlSingleLogoutServiceUrlPost { get; set; }

        /// <summary>
        /// SAML ARTIFACT Binding URL for the client's single logout service. You can leave this blank if you are using a different binding.
        /// </summary>
        [JsonProperty("saml_single_logout_service_url_artifact")]
        public Uri? SamlSingleLogoutServiceUrlArtifact { get; set; }

        /// <summary>
        /// SAML Redirect Binding URL for the client's single logout service. You can leave this blank if you are using a different binding.
        /// </summary>
        [JsonProperty("saml_single_logout_service_url_redirect")]
        public Uri? SamlSingleLogoutServiceUrlRedirect { get; set; }

        /// <summary>
        /// This enables support for OAuth 2.0 Mutual TLS Certificate Bound Access Tokens, which means that keycloak bind an access token and a refresh token with a X.509 certificate
        /// of a token requesting client exchanged in mutual TLS between keycloak's Token Endpoint and this client. These tokens can be treated as Holder-of-Key tokens instead of bearer tokens.
        /// </summary>
        [JsonProperty("tls.client.certificate.bound.access.tokens")]
        public bool? TlsClientCertificateBoundAccessTokens { get; set; }

        /// <summary>
        /// JWA algorithm used for signed User Info Endpoint response. If set to 'unsigned', User Info Response won't be signed and will be returned in application/json format.
        /// </summary>
        [JsonProperty("user.info.response.signature.alg")]
        public string? UserInfoResponseSignatureAlg { get; set; }

        /// <summary>
        /// If this is on, a refresh_token will be created and added to the token response. If this is off then no refresh_token will be generated.
        /// </summary>
        [JsonProperty("use.refresh.tokens")] 
        public bool? UseRefreshTokens { get; set; }
    }
}
