﻿using Newtonsoft.Json;

namespace Keycloak.Net.Model.Root
{
    public class ExportProviders
    {
        [JsonProperty("singleFile")]
        public HasOrder SingleFile { get; set; }

        [JsonProperty("dir")]
        public HasOrder Dir { get; set; }
    }
}