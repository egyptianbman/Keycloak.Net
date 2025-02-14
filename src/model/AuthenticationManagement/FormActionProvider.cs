﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.AuthenticationManagement
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_getformactionproviders
    /// </summary>
    public class FormActionProvider
    {
        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
