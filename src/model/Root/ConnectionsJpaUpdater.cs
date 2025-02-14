﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ConnectionsJpaUpdater
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ConnectionsJpaUpdaterProviders Providers { get; set; }
    }
}