namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// Keycloak OAuth2 constants.
    /// </summary>
    /// <remarks>
    /// See <include file='../../keycloak.xml' path='keycloak/docs/github' />/core/src/main/java/org/keycloak/OAuth2Constants.java
    /// </remarks>
    public static class OAuth2Constants
    {
        public const string CODE = "code";

        public const string TOKEN = "token";

        public const string CLIENT_ID = "client_id";

        public const string CLIENT_SECRET = "client_secret";

        public const string ERROR = "error";

        public const string ERROR_DESCRIPTION = "error_description";

        public const string REDIRECT_URI = "redirect_uri";

        public const string DISPLAY = "display";

        public const string SCOPE = "scope";

        public const string STATE = "state";

        public const string GRANT_TYPE = "grant_type";

        public const string RESPONSE_TYPE = "response_type";

        public const string ACCESS_TOKEN = "access_token";

        public const string TOKEN_TYPE = "token_type";

        public const string EXPIRES_IN = "expires_in";

        public const string ID_TOKEN = "id_token";

        public const string REFRESH_TOKEN = "refresh_token";

        public const string LOGOUT_TOKEN = "logout_token";

        public const string AUTHORIZATION_CODE = "authorization_code";

        public const string IMPLICIT = "implicit";

        public const string USERNAME = "username";

        public const string PASSWORD = "password";

        public const string CLIENT_CREDENTIALS = "client_credentials";

        // https://tools.ietf.org/html/draft-ietf-oauth-assertions-01#page-5
        public const string CLIENT_ASSERTION_TYPE = "client_assertion_type";
        public const string CLIENT_ASSERTION = "client_assertion";

        // https://tools.ietf.org/html/draft-jones-oauth-jwt-bearer-03#section-2.2
        public const string CLIENT_ASSERTION_TYPE_JWT = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";

        // http://openid.net/specs/openid-connect-core-1_0.html#OfflineAccess
        public const string OFFLINE_ACCESS = "offline_access";

        // http://openid.net/specs/openid-connect-core-1_0.html#AuthRequest
        public const string SCOPE_OPENID = "openid";

        // http://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims
        public const string SCOPE_PROFILE = "profile";
        public const string SCOPE_EMAIL = "email";
        public const string SCOPE_ADDRESS = "address";
        public const string COPE_PHONE = "phone";

        public const string UI_LOCALES_PARAM = "ui_locales";

        public const string PROMPT = "prompt";
        public const string ACR_VALUES = "acr_values";

        public const string MAX_AGE = "max_age";

        // OIDC Session Management
        public const string SESSION_STATE = "session_state";

        public const string JWT = "JWT";

        // https://tools.ietf.org/html/rfc7636#section-6.1
        public const string CODE_VERIFIER = "code_verifier";
        public const string CODE_CHALLENGE = "code_challenge";
        public const string CODE_CHALLENGE_METHOD = "code_challenge_method";

        // https://tools.ietf.org/html/rfc7636#section-6.2.2
        public const string PKCE_METHOD_PLAIN = "plain";
        public const string PKCE_METHOD_S256 = "S256";


        // https://tools.ietf.org/html/rfc8693#section-2.1
        public const string TOKEN_EXCHANGE_GRANT_TYPE = "urn:ietf:params:oauth:grant-type:token-exchange";
        public const string AUDIENCE = "audience";
        public const string RESOURCE = "resource";
        public const string REQUESTED_SUBJECT = "requested_subject";
        public const string SUBJECT_TOKEN = "subject_token";
        public const string SUBJECT_TOKEN_TYPE = "subject_token_type";
        public const string ACTOR_TOKEN = "actor_token";
        public const string ACTOR_TOKEN_TYPE = "actor_token_type";
        public const string REQUESTED_TOKEN_TYPE = "requested_token_type";
        public const string ISSUED_TOKEN_TYPE = "issued_token_type";
        public const string REQUESTED_ISSUER = "requested_issuer";
        public const string SUBJECT_ISSUER = "subject_issuer";
        public const string ACCESS_TOKEN_TYPE = "urn:ietf:params:oauth:token-type:access_token";
        public const string REFRESH_TOKEN_TYPE = "urn:ietf:params:oauth:token-type:refresh_token";
        public const string JWT_TOKEN_TYPE = "urn:ietf:params:oauth:token-type:jwt";
        public const string ID_TOKEN_TYPE = "urn:ietf:params:oauth:token-type:id_token";
        public const string SAML2_TOKEN_TYPE = "urn:ietf:params:oauth:token-type:saml2";
        public const string UMA_GRANT_TYPE = "urn:ietf:params:oauth:grant-type:uma-ticket";

        // https://tools.ietf.org/html/draft-ietf-oauth-device-flow-15#section-3.4
        public const string DEVICE_CODE_GRANT_TYPE = "urn:ietf:params:oauth:grant-type:device_code";
        public const string DEVICE_CODE = "device_code";
        public const string CIBA_GRANT_TYPE = "urn:openid:params:grant-type:ciba";
        public const string DISPLAY_CONSOLE = "console";
        public const string INTERVAL = "interval";
        public const string USER_CODE = "user_code";

        // https://openid.net/specs/openid-financial-api-jarm-ID1.html
        public const string RESPONSE = "response";
    }
}
