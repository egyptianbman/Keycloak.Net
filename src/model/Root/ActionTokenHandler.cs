﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ActionTokenHandler
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ActionTokenHandlerProviders Providers { get; set; } = null!;
    }
}