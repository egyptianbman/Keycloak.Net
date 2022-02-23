using System.Collections.Generic;
using Keycloak.Net.Model.Common;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ProtocolMapperType
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        /// <inheritdoc cref="Category"/>
        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("helpText")]
        public string HelpText { get; set; } = null!;

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("properties")]
        public IEnumerable<ConfigProperty> Properties { get; set; } = null!;
    }
}