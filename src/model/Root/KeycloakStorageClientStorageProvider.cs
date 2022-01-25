﻿using System.Collections.Generic;
using Keycloak.Net.Model.Common;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class KeycloakStorageClientStorageProvider
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("helpText")]
        public string? HelpText { get; set; }

        [JsonProperty("properties")]
        public IEnumerable<ConfigProperty>? Properties { get; set; }

        [JsonProperty("metadata")]
        public KeycloakStorageClientStorageProviderMetadata? Metadata { get; set; }
    }
}