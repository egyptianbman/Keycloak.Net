using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Groups;
using Keycloak.Net.Shared.Json;

namespace Keycloak.Net
{
    /// <remarks>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_groups_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/groups <br/>
        /// Create or add a top level realm groupSet or create child.
        /// </summary>
        /// <remarks>
        /// This will update the group and set the parent if it exists. Create it and set the parent if the group doesn't exist.
        /// </remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="group"></param>
        public async Task<bool> CreateGroupAsync(string realm, Group group)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups")
                .PostJsonAsync(group)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// GET /{realm}/groups <br/>
        /// Get group hierarchy.
        /// </summary>
        /// <remarks>
        /// Only name and ids are returned.
        /// </remarks>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="briefRepresentation"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="search"></param>
        public async Task<IEnumerable<Group>> GetGroupsAsync(
            string realm, 
            bool? briefRepresentation = null,
            int? first = null, 
            int? max = null, 
            string? search = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(briefRepresentation)] = briefRepresentation,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(search)] = search,
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Group>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/groups/count <br/>
        /// Returns the groups counts.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="search"></param>
        /// <param name="top"></param>
        public async Task<int> GetGroupsCountAsync(
            string realm, 
            string? search = null, 
            bool? top = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(search)] = search,
                [nameof(top)] = top
            };

            var result = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/count")
                .SetQueryParams(queryParams)
                .GetJsonAsync()
                .ConfigureAwait(false);

            return Convert.ToInt32(DynamicExtensions.GetFirstPropertyValue(result));
        }

        /// <summary>
        /// GET /{realm}/groups/{id} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        public async Task<Group> GetGroupByIdAsync(string realm, string groupId)
        {
            var result = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
                .GetJsonAsync<Group>()
                .ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// PUT /{realm}/groups/{id} <br/>
        /// Update group, ignores subgroups.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="group"></param>
        public async Task<bool> UpdateGroupByIdAsync(string realm, string groupId, Group group)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
                .PutJsonAsync(group)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/groups/{id} <br/>
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        public async Task<bool> DeleteGroupByIdAsync(string realm, string groupId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/groups/{id}/children <br/>
        /// Set or create child.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="groupId"></param>
        /// <param name="group"></param>
        public async Task<bool> SetOrCreateGroupChildAsync(string realm, string groupId, Group group)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/children")
                .PostJsonAsync(group)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
