using System.Collections.Generic;
using System.ComponentModel;
using Keycloak.Net.Model.AuthorizationManagement;
using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_scoperepresentation
    /// </summary>
    public class AuthorizationPolicy
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <inheritdoc cref="PolicyType"/>
        [JsonProperty("type")]
        public PolicyType Type { get; set; } = PolicyType.Role;

        /// <inheritdoc cref="PolicyDecisionLogic"/>
        [JsonProperty("logic")]
        public PolicyDecisionLogic Logic { get; set; }

        /// <inheritdoc cref="DecisionStrategy"/>
        public DecisionStrategy DecisionStrategy { get; set; }

        [JsonProperty("roles")]
        public IEnumerable<RoleConfig>? RoleConfigs { get; set; }
    }

    public class RoleConfig
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("required")]
        public bool? Required { get; set; }
    }

    [JsonConverter(typeof(JsonEnumConverter<PolicyType>))]
    public enum PolicyType
    {
        [Description("role")]
        Role,

        [Description("client")]
        Client,

        [Description("time")]
        Time,

        [Description("user")]
        User,

        [Description("aggregate")]
        Aggregate,

        [Description("group")]
        Group,

        [Description("js")]
        Js
    }

    public class PolicyConfig
    {
        [JsonProperty("roles")]
        public IEnumerable<RoleConfig>? RoleConfigs { get; set; }
    }
}