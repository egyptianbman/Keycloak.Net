using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// The keycloak error object
    /// </summary>
    public class KeycloakError
    {
        /// <summary>
        /// The serialized error message.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; } = string.Empty;
    }
}
