using Keycloak.Net.Shared.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Keycloak.Net.Model.Root
{
    [JsonConverter(typeof(JsonEnumConverter<Category>))]
    public enum Category
    {
        [Description("attribute statement mapper")]
        AttributeStatementMapper,

        [Description("docker auth mapper")]
        DockerAuthMapper,

        [Description("group mapper")]
        GroupMapper,

        [Description("role mapper")]
        RoleMapper,

        [Description("token mapper")]
        TokenMapper
    }
}