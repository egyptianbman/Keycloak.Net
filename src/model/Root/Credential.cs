﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class Credential
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public CredentialProviders Providers { get; set; }
    }
}