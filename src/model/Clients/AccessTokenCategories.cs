using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_accesstoken
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<AccessTokenCategories>))]
    public enum AccessTokenCategories
    {
        [Description("INTERNAL")]
        Internal,

        [Description("ACCESS")]
        Access,

        [Description("ID")]
        Id,

        [Description("ADMIN")]
        Admin,

        [Description("USERINFO")]
        UserInfo,

        [Description("LOGOUT")]
        Logout,

        [Description("AUTHORIZATION_RESPONSE")]
        AuthorizationResponse
    }
}
