﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Net.Model.Clients
{
    /// <summary>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_resourcerepresentation
    /// </summary>
    public class Resource
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("attributes")]
        public IDictionary<string, object>? Attributes { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("icon_uri")]
        public string? IconUri { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("ownerManagedAccess")]
        public bool OwnerManagedAccess { get; set; }

        [JsonProperty("scopes")]
        public IEnumerable<Scope>? Scopes { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("uris")]
        public IEnumerable<string>? Uris { get; set; }
    }
}
