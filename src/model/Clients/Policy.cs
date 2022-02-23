using System.Collections.Generic;
using Keycloak.Net.Model.AuthorizationManagement;
using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    public class Policy
    {
        [JsonProperty("config")]
        public PolicyConfig? Config { get; set; }
        
        [JsonProperty("decisionStrategy")]
        public DecisionStrategy? DecisionStrategy { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <inheritdoc cref="PolicyDecisionLogic"/>
        [JsonProperty("logic")]
        public PolicyDecisionLogic? Logic { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("owner")]
        public string? Owner { get; set; }

        [JsonProperty("policies")]
        public IEnumerable<string>? Policies { get; set; }

        [JsonProperty("resources")]
        public IEnumerable<string>? Resources { get; set; }

        [JsonProperty("resourcesData")]
        public IEnumerable<Resource>? ResourcesData { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<string>? Scopes { get; set; }

        [JsonProperty("scopesData")]
        public IEnumerable<Scope>? ScopesData { get; set; }

        /// <inheritdoc cref="PolicyType"/>
        [JsonProperty("type")]
        public PolicyType? Type { get; set; }

    }
}
