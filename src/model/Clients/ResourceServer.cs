using System.Collections.Generic;
using Keycloak.Net.Model.AuthorizationManagement;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_resourceserverrepresentation
    /// </summary>
    public class ResourceServer
    {
        [JsonProperty("allowRemoteResourceManagement")]
        public bool AllowRemoteResourceManagement { get; set; }

        [JsonProperty("clientId")]
        public string? ClientId { get; set; }

        /// <inheritdoc cref="DecisionStrategy"/>
        [JsonProperty("decisionStrategy")]
        public DecisionStrategy? DecisionStrategy { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("policies")]
        public IEnumerable<Policy>? Policies { get; set; }

        /// <inheritdoc cref="Clients.PolicyEnforcementMode" />
        [JsonProperty("policyEnforcementMode")]
        public PolicyEnforcementMode? PolicyEnforcementMode { get; set; }

        [JsonProperty("resources")]
        public IEnumerable<Resource>? Resources { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<Scope>? Scopes { get; set; }
    }
}
