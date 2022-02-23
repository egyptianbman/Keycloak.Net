using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    /// <summary>
    /// The keycloak error object
    /// </summary>
    public class KeycloakError
    {
        /// <summary>
        /// The error message.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; } = string.Empty;

        /// <summary>
        /// The detailed error description.
        /// </summary>
        [JsonProperty("error_description")]
        public string? ErrorDescription { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return !string.IsNullOrEmpty(ErrorDescription) ? $"{Error}: {ErrorDescription}" : Error;
        }
    }
}
