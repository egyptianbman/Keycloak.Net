using System.Collections.Generic;
using System.ComponentModel;
using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthorizationManagement
{
    /// <summary>
    /// The client authorization service settings
    /// </summary>
    public class AuthorizationPermission
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <inheritdoc cref="AuthorizationPermissionType" />
        [JsonProperty("type")]
        public AuthorizationPermissionType Type { get; set; }

        /// <inheritdoc cref="PolicyDecisionLogic"/>
        [JsonProperty("logic")]
        public PolicyDecisionLogic Logic { get; set; }

        /// <inheritdoc cref="AuthorizationManagement.DecisionStrategy"/>
        [JsonProperty("decisionStrategy")]
        public DecisionStrategy DecisionStrategy { get; set; }

        [JsonProperty("resourceType")]
        public string? ResourceType { get; set; }

        [JsonProperty("resources")]
        public IEnumerable<string>? ResourceIds { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<string>? ScopeIds { get; set; }

        [JsonProperty("policies")]
        public IEnumerable<string>? PolicyIds { get; set; }
    }

    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<PolicyDecisionLogic>))]
    public enum PolicyDecisionLogic
    {
        [Description("POSITIVE")]
        Positive,

        [Description("NEGATIVE")]
        Negative
    }

    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<AuthorizationPermissionType>))]
    public enum AuthorizationPermissionType
    {   
        [Description("scope")]
        Scope,

        [Description("resource")]
        Resource
    }

    /// <summary>
    /// The decision strategy dictates how the policies associated with a given policy are evaluated and how a final decision is obtained.
    /// <include file='../../keycloak.xml' path='keycloak/docs/javadocs' />/org/keycloak/representations/idm/authorization/DecisionStrategy.html
    /// </summary>
    [JsonConverter(typeof(JsonEnumConverter<DecisionStrategy>))]
    public enum DecisionStrategy
    {
        /// <summary>
        /// Defines that at least one policy must evaluate to a positive decision in order to the overall decision be also positive.
        /// </summary>
        [Description("AFFIRMATIVE")]
        Affirmative,

        /// <summary>
        /// Defines that the number of positive decisions must be greater than the number of negative decisions.
        /// </summary>
        [Description("CONSENSUS")]
        Consensus,

        /// <summary>
        /// Defines that all policies must evaluate to a positive decision in order to the overall decision be also positive.
        /// </summary>
        [Description("UNANIMOUS")]
        Unanimous
    }
}