﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Users
{
    public class SetPasswordResponse
    {
        public bool Success { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}