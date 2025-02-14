﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class RequiredAction
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public RequiredActionProviders? Providers { get; set; }
    }
}