using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuth2TokenIntrospection
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public OAuth2TokenIntrospectionProviders Providers { get; set; }
    }
}