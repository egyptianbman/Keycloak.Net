﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Policy
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public PolicyProviders Providers { get; set; }
    }
}