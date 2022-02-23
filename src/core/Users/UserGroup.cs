using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Groups;
using Keycloak.Net.Shared.Json;

namespace Keycloak.Net
{
    /// <remarks>
    /// Manage user groups. <br/>
    /// <include file='../../keycloak.xml' path='keycloak/docs/api' />#_users_resource
    /// </remarks>
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/users/{userId}/groups <br/>
        /// Get groups that is associated with the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="briefRepresentation"></param>
        /// <param name="first"></param>
        /// <param name="max"></param>
        /// <param name="search"></param>
        public async Task<IEnumerable<Group>?> GetUserGroupsAsync(
            string realm,
            string userId,
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
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Group>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/users/{userId}/groups/count <br/>
        /// Get total group count that is associated with the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        public async Task<int> GetUserGroupsCountAsync(string realm, string userId)
        {
            var result = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/count")
                .GetJsonAsync()
                .ConfigureAwait(false);
            return Convert.ToInt32(DynamicExtensions.GetFirstPropertyValue(result));
        }

        /// <summary>
        /// PUT /{realm}/users/{userId}/groups/{groupId} <br/>
        /// Update the group assignment for the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="groupId">group id</param>
        public async Task<bool> UpdateUserGroupAsync(string realm, string userId, string groupId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/{groupId}")
                .PutAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/users/{userId}/groups/{groupId} <br/>
        /// Remove the group assignment for the user.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="userId">user id</param>
        /// <param name="groupId">group id</param>
        public async Task<bool> DeleteUserGroupAsync(string realm, string userId, string groupId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/{groupId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

    }
}
