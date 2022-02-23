using System.Collections.Generic;
using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_idtoken
    /// </summary>
    public class IdToken
    {
        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/Acr">Acr</a> is an Abbreviation and or a OAuth Parameters Registry entry for Authentication Context Class Reference.
        /// </summary>
        [JsonProperty("acr")]
        public string? Acr { get; set; }

        /// <summary>
        /// End-User's preferred postal address. The value of the <c>address</c> member is a JSON <a href="https://openid.net/specs/openid-connect-core-1_0.html#RFC4627">[RFC4627]</a>
        /// structure containing some or all of the members defined in <a href="https://openid.net/specs/openid-connect-core-1_0.html#AddressClaim">Section 5.1.1</a>.
        /// </summary>
        [JsonProperty("address")]
        public AddressClaimSet? Address { get; set; }
        
        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/at_hash">At_hash</a> value is the base64url encoding of the left-most half of the hash of the octets of the ASCII representation of the access_token value,
        /// where the hash algorithm used is the hash algorithm used in the <c>alg</c> Header Parameter of the Identity Token's JOSE Header. <br/>
        /// For Example, if the <c>alg</c> is RS256, hash the access_token value with SHA-256, then take the left-most 128 bits and base64url encode them.
        /// </summary>
        [JsonProperty("at_hash")]
        public string? AtHash { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/auth_time">Auth_time</a> is a JSON Web Token Claim indicating the time when the authentication occurred.
        /// </summary>
        [JsonProperty("auth_time")]
        public int? AuthTime { get; set; }

        /// <summary>
        /// The <a href="https://ldapwiki.com/wiki/aud">"Aud"</a> (audience) OPTIONAL Reserved Claim Name identifies the recipients that the JSON Web Token is intended for.
        /// Each principal intended to process the JWT MUST identify itself with a value in the audience JSON Web Token Claim. <br/>
        /// If the principal processing the claim does not identify itself with a value in the "Aud" claim when this JSON Web Token Claim is present, then the JWT MUST be rejected.
        /// </summary>
        [JsonProperty("aud")]
        public string? Aud { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/azp">Azp</a> is an id_token parameter which represents the Authorized party.
        /// </summary>
        [JsonProperty("azp")]
        public string? Azp { get; set; }

        /// <summary>
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">End-User's birthday</a>, represented as an
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ISO8601-2004">ISO 8601:2004</a> [ISO8601‑2004] <c>YYYY-MM-DD</c> format.
        /// The year MAY be <c>0000</c>, indicating that it is omitted. To represent only the year, <c>YYYY</c> format is allowed. <br/>
        /// Note that depending on the underlying platform's date related function, providing just year can result in varying month and day,
        /// so the implementers need to take this factor into account to correctly process the dates.
        /// </summary>
        [JsonProperty("birthdate")]
        public string? Birthdate { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/c_hash">C_hash</a> value is the base64url encoding of the left-most half of the hash of the octets of the ASCII representation of the code value,
        /// where the hash algorithm used is the hash algorithm used in the <c>alg</c> Header Parameter of the id_token's JOSE Header.
        /// For instance, if the <c>alg</c> is HS512, hash the code value with SHA-512, then take the left-most 256 bits and base64url encode them.
        /// </summary>
        [JsonProperty("c_hash")]
        public string? CHash { get; set; }

        [JsonProperty("category")]
        public AccessTokenCategories? Category { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/claims_locales">Claims_locales</a> is an OPTIONAL OAuth Parameters Registry entry used in OpenID Connect to indicate the End-User's preferred languages and scripts for Claims being returned,
        /// represented as a space-separated list of BCP 47 (RFC 5646) Language-Tag values, ordered by preference.
        /// </summary>
        [JsonProperty("claims_locales")]
        public string? ClaimsLocales { get; set; }

        /// <summary>
        /// End-User's preferred e-mail address. Its value MUST conform to the <a href="https://openid.net/specs/openid-connect-core-1_0.html#RFC5322">[RFC5322]</a> addr-spec syntax.
        /// The RP MUST NOT rely upon this value being unique, as discussed in <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimStability">Section 5.7</a>.
        /// </summary>
        [JsonProperty("email")]
        public string? Email { get; set; }

        /// <summary>
        /// True if the End-User's e-mail address has been verified; otherwise false.
        /// When this Claim Value is true, this means that the OP took affirmative steps to ensure that this e-mail address was controlled by the End-User at the time the verification was performed.
        /// The means by which an e-mail address is verified is context-specific, and dependent upon the trust framework or contractual agreements within which the parties are operating.
        /// </summary>
        [JsonProperty("email_verified")]
        public bool? EmailVerified { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/exp">Exp</a> (Expiration Time) OPTIONAL Reserved Claim Name identifies the expiration time on or after which the JSON Web Token MUST NOT be accepted for processing. <br/>
        /// The processing of the "Exp" claim requires that the current date/time MUST be before the expiration date/time listed in the "Exp" claim.
        /// </summary>
        [JsonProperty("exp")]
        public long? Exp { get; set; }

        /// <summary>
        /// Surname(s) or last name(s) of the End-User. Note that in some cultures, people can have multiple family names or no family name; all can be present, with the names being separated by space characters.
        /// </summary>
        [JsonProperty("family_name")]
        public string? FamilyName { get; set; }

        /// <summary>
        /// End-User's gender. Values defined by this specification are <c>female</c> and <c>male</c>.
        /// Other values MAY be used when neither of the defined values are applicable.
        /// </summary>
        [JsonProperty("gender")]
        public string? Gender { get; set; }

        /// <summary>
        /// Given name(s) or first name(s) of the End-User. Note that in some cultures, people can have multiple given names; all can be present, with the names being separated by space characters.
        /// </summary>
        [JsonProperty("given_name")]
        public string? GivenName { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/iat">Iat</a> (issued at) OPTIONAL Reserved Claim Name identifies the time at which the JWT was issued.
        /// The Iat claim can be used to determine the age of the JWT.
        /// </summary>
        [JsonProperty("iat")]
        public long? Iat { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/iss">Iss</a> (issuer) in the Access Token identifies the Digital Identity that issued the Access Token.
        /// </summary>
        [JsonProperty("iss")]
        public string? Iss { get; set; }

        /// <summary>
        /// The <a href="https://ldapwiki.com/wiki/jti">Jti</a> (JWT ID) OPTIONAL Reserved Claim Name that provides a unique identifier for the JSON Web Token. <br/>
        /// The identifier value MUST be assigned in a manner that ensures that there is a negligible probability that the same value will be accidentally assigned to a different data object;
        /// if the application uses multiple issuers, collisions MUST be prevented among values produced by different issuers as well.
        /// </summary>
        [JsonProperty("jti")]
        public string? Jti { get; set; }

        /// <summary>
        /// Country code in uppercase, separated by a dash. For example, <c>en-US</c> or <c>fr-CA</c>. <br/>
        /// As a compatibility note, some implementations have used an underscore as the separator rather than a dash,
        /// for example, en_US; Relying Parties MAY choose to accept this locale syntax as well.
        /// </summary>
        [JsonProperty("locale")]
        public string? Locale { get; set; }

        /// <summary>
        /// Middle name(s) of the End-User. Note that in some cultures, people can have multiple middle names; all can be present, with the names being separated by space characters. Also note that in some cultures, middle names are not used.
        /// </summary>
        [JsonProperty("middle_name")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// End-User's full name in displayable form including all name parts, possibly including titles and suffixes, ordered according to the End-User's locale and preferences.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/nbf">Nbf</a> means "Not Before" and is a Reserved Claim Name defined in <a href="https://ldapwiki.com/wiki/RFC%207519">RFC7519 Section 4.1.5</a>
        /// The "Nbf" (not before) JSON Web Token Claim identifies the time before which the JWT MUST NOT be accepted for processing.
        /// The processing of the "Nbf" JSON Web Token Claim requires that the current date/time MUST be after or equal to the not-before date/time listed in the "Nbf" claim. <br/><br/>
        /// Implementers MAY provide for some small leeway, usually no more than a few minutes, to account for clock skew.Its value MUST be a number containing a NumericDate value.
        /// </summary>
        [JsonProperty("nbf")]
        public long? Nbf { get; set; }

        /// <summary>
        /// Casual name of the End-User that may or may not be the same as the <c>given_name</c>. For instance, a <c>nickname</c> value of Mike might be returned alongside a <c>given_name</c> value of Michael.
        /// </summary>
        [JsonProperty("nickname")]
        public string? Nickname { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/nonce">Nonce</a> ("number used once") is, typically a randomly generated value (technically does not need to be a number) that's associated with a message in a cryptographic scheme
        /// and must be unique within some specified scope (such as a given time interval, or a session).
        /// Nonce typically used to prevent <a href="https://ldapwiki.com/wiki/Replay%20attack">Replay attack</a>.
        /// </summary>
        [JsonProperty("nonce")]
        public string? Nonce { get; set; }

        [JsonProperty("otherClaims")]
        public IDictionary<string, object>? OtherClaims { get; set; }

        /// <summary>
        /// End-User's preferred telephone number. <a href="https://openid.net/specs/openid-connect-core-1_0.html#E.164">[E.164]</a> is RECOMMENDED as the format of this Claim, for example, +1 (425) 555-1212 or +56 (2) 687 2400.
        /// If the phone number contains an extension, it is RECOMMENDED that the extension be represented using the <a href="https://openid.net/specs/openid-connect-core-1_0.html#RFC3966">[RFC3966]</a> extension syntax, for example, +1 (604) 555-1234;ext=5678.
        /// </summary>
        [JsonProperty("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// True if the End-User's phone number has been verified; otherwise false. When this Claim Value is true, this means that the OP took affirmative steps to ensure that this phone number
        /// was controlled by the End-User at the time the verification was performed. The means by which a phone number is verified is context-specific, and dependent upon the trust framework
        /// or contractual agreements within which the parties are operating. When true, the phone_number Claim MUST be in <a href="https://openid.net/specs/openid-connect-core-1_0.html#E.164">[E.164]</a> format and
        /// any extensions MUST be represented in <a href="https://openid.net/specs/openid-connect-core-1_0.html#RFC3966">[RFC3966]</a> format.
        /// </summary>
        [JsonProperty("phone_number_verified")]
        public bool? PhoneNumberVerified { get; set; }

        /// <summary>
        /// URL of the End-User's profile picture. This URL MUST refer to an image file (for example, a PNG, JPEG, or GIF image file), rather than to a Web page containing an image.
        /// Note that this URL SHOULD specifically reference a profile photo of the End-User suitable for displaying when describing the End-User, rather than an arbitrary photo taken by the End-User.
        /// </summary>
        [JsonProperty("picture")]
        public string? Picture { get; set; }

        /// <summary>
        /// Shorthand name by which the End-User wishes to be referred to at the RP, such as janedoe or j.doe.
        /// This value MAY be any valid JSON string including special characters such as @, /, or whitespace.
        /// The RP MUST NOT rely upon this value being unique, as discussed in <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimStability">Section 5.7</a>.
        /// </summary>
        [JsonProperty("preferred_username")]
        public string? PreferredUsername { get; set; }

        /// <summary>
        /// URL of the End-User's profile page. The contents of this Web page SHOULD be about the End-User.
        /// </summary>
        [JsonProperty("profile")]
        public string? Profile { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/s_hash">S_hash</a> is the OAuth state parameter hash value and is the base64url encoding of the left-most half of the hash of the octets of the ASCII representation
        /// of the state value, where the hash algorithm used is id_token's <c>alg</c> JOSE Header Parameter Header. <br/><br/>
        /// For example, if the alg is HS512, hash the code value with SHA-512, then take the left-most 256 bits and base64url encode them.
        /// </summary>
        [JsonProperty("s_hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// <a href="https://openid.net/specs/openid-connect-session-1_0.html#CreatingUpdatingSessions">Session_state</a> is a JSON string that represents the End-User's login state at the OP.
        /// It MUST NOT contain the space (" ") character. This value is opaque to the RP. This is REQUIRED if session management is supported.
        /// </summary>
        [JsonProperty("session_state")]
        public string? SessionState { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/sid">Sid</a> (Session ID) is defined in OpenID Connect Front-Channel Logout and OpenID Connect Back-Channel Logout as an OPTIONAL String identifier for a Session.
        /// </summary>
        [JsonProperty("sid")]
        public string? Sid { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/sub">Sub</a> (Subject) - Identifier for the End-User at the Issuer.
        /// </summary>
        [JsonProperty("sub")]
        public string? Sub { get; set; }

        /// <summary>
        /// <a href="https://ldapwiki.com/wiki/typ">Typ</a> is an Abbreviation of Type as often used within JSON
        /// </summary>
        [JsonProperty("typ")]
        public string? Typ { get; set; }

        /// <summary>
        /// Time the End-User's information was last updated. Its value is a JSON number representing the number of seconds from 1970-01-01T0:0:0Z as measured in UTC until the date/time.
        /// </summary>
        [JsonProperty("updated_at")]
        public long? UpdatedAt { get; set; }

        /// <summary>
        /// URL of the End-User's Web page or blog. This Web page SHOULD contain information published by the End-User or an organization that the End-User is affiliated with.
        /// </summary>
        [JsonProperty("website")]
        public string? Website { get; set; }

        /// <summary>
        /// String from <a href="https://openid.net/specs/openid-connect-core-1_0.html#zoneinfo">[zoneinfo]</a> time zone database representing the End-User's time zone. For example, Europe/Paris or America/Los_Angeles.
        /// </summary>
        [JsonProperty("zoneinfo")]
        public string? Zoneinfo { get; set; }
    }
}
