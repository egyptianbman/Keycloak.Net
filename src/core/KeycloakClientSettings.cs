namespace Keycloak.Net
{
    /// <summary>
    /// <see cref="KeycloakClient"/> settings.
    /// </summary>
    public class KeycloakClientSettings
    {
        internal static KeycloakClientSettings Default => new KeycloakClientSettings
        {
            ReturnNullOnNotFound = false
        };

        /// <summary>
        /// Indicates if the HTTP request should return <see langword="null"/> if it's not found, i.e. status 404. <br/>
        /// The default behaviour is to throw exception. <br/>
        /// Default: false
        /// </summary>
        public bool ReturnNullOnNotFound { get; set; }
    }
}
