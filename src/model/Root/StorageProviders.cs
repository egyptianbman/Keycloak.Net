﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class StorageProviders
    {
        [JsonProperty("ldap")]
        public HasOrder Ldap { get; set; }

        [JsonProperty("kerberos")]
        public HasOrder Kerberos { get; set; }
    }
}