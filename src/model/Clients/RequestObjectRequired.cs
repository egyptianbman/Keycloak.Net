using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// Specifies if the client needs to provide a request object with their authorization requests, and what method they can use for this.
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<RequestObjectRequired>))]
    public enum RequestObjectRequired
    {
        /// <summary>
        /// Providing a request object is optional. In all other cases, providing a request object is mandatory.
        /// </summary>
        [Description("not required")]
        NotRequired,

        /// <summary>
        /// The request object must be provided by value.
        /// </summary>
        [Description("request only")]
        Request,

        /// <summary>
        /// The request object must be provided by reference.
        /// </summary>
        [Description("request_uri only")]
        RequestUri,

        /// <summary>
        /// Either method can be used.
        /// </summary>
        [Description("request or request_uri")]
        RequestOrRequestUri
    }
}
