using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Users;
using Keycloak.Net.Shared.Json;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// GET /{realm}/clients/{clientId}/evaluate-scopes/generate-example-access-token <br/>
        /// Create JSON with payload of example access token.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="scope"></param>
        /// <param name="userId"></param>
        public async Task<AccessToken?> GenerateClientExampleAccessTokenAsync(
            string realm,
            string clientId,
            string? scope = null,
            string? userId = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(scope)] = scope,
                [nameof(userId)] = userId
            };

            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/evaluate-scopes/generate-example-access-token")
                .SetQueryParams(queryParams)
                .GetJsonAsync<AccessToken>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/evaluate-scopes/generate-example-id-token <br/>
        /// Create JSON with payload of example id token
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="scope"></param>
        /// <param name="userId"></param>
        public async Task<IdToken?> GenerateClientExampleIdTokenAsync(
            string realm,
            string clientId,
            string? scope = null,
            string? userId = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(scope)] = scope,
                [nameof(userId)] = userId
            };

            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/evaluate-scopes/generate-example-id-token")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IdToken>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{id}/evaluate-scopes/generate-example-userinfo <br/>
        /// Create JSON with payload of example user info
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="scope"></param>
        /// <param name="userId"></param>
        public async Task<IDictionary<string, object>?> GenerateClientExampleUserInfoAsync(
            string realm,
            string clientId,
            string? scope = null,
            string? userId = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(scope)] = scope,
                [nameof(userId)] = userId
            };

            var response = await GetBaseUrl()
                .AppendPathSegment(
                    $"/admin/realms/{realm}/clients/{clientId}/evaluate-scopes/generate-example-userinfo")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IDictionary<string, object>>()
                .ConfigureAwait(false);
            return response;
        }
        
        /// <summary>
        /// POST /{realm}/clients/{clientId}/push-revocation <br/>
        /// Push the client’s revocation policy to its admin URL If the client has an admin URL, push revocation policy to it.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<GlobalRequestResult?> PushClientRevocationPolicyAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/push-revocation")
                .PostAsync()
                .ReceiveJson<GlobalRequestResult>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// POST /{realm}/clients/{clientId}/registration-access-token <br/>
        /// Generate a new registration access token for the client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<Client?> GenerateClientRegistrationAccessTokenAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/registration-access-token")
                .PostAsync()
                .ReceiveJson<Client>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/evaluate-scopes/protocol-mappers <br/>
        /// Return list of all protocol mappers, which will be used when generating tokens issued for particular client.<br/>
        /// This means protocol mappers assigned to this client directly and protocol mappers assigned to all client scopes of this client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="scope"></param>
        public async Task<IEnumerable<ClientScopeEvaluateResourceProtocolMapperEvaluation>?>
            GetProtocolMappersInTokenGenerationAsync(
                string realm,
                string clientId,
                string? scope = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(scope)] = scope
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/evaluate-scopes/protocol-mappers")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<ClientScopeEvaluateResourceProtocolMapperEvaluation>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/session-count <br/>
        /// Get application session count. Returns a number of user sessions associated with this client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<int> GetClientSessionCountAsync(string realm, string clientId)
        {
            var result = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/session-count")
                .GetJsonAsync()
                .ConfigureAwait(false);

            return Convert.ToInt32(DynamicExtensions.GetFirstPropertyValue(result));
        }

        /// <summary>
        /// GET /{realm}/clients/{id}/user-sessions <br/>
        /// Get user sessions for client Returns a list of user sessions associated with this client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="first">paging offset</param>
        /// <param name="max">maximum results size (defaults to 100)</param>
        public async Task<IEnumerable<UserSession>?> GetClientUserSessionsAsync(
            string realm,
            string clientId,
            int? first = null,
            int? max = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(first)] = first,
                [nameof(max)] = max
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/user-sessions")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<UserSession>>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/offline-session-count <br/>
        /// Get application offline session count. Returns a number of offline user sessions associated with this client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<int> GetClientOfflineSessionCountAsync(string realm, string clientId)
        {
            var result = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/offline-session-count")
                .GetJsonAsync()
                .ConfigureAwait(false);

            return Convert.ToInt32(DynamicExtensions.GetFirstPropertyValue(result));
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/offline-sessions <br/>
        /// Get offline sessions for client. Returns a list of offline user sessions associated with this client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="first">paging offset</param>
        /// <param name="max">maximum results size (defaults to 100)</param>
        public async Task<IEnumerable<UserSession>?> GetClientOfflineSessionsAsync(
            string realm,
            string clientId,
            int? first = null,
            int? max = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(first)] = first,
                [nameof(max)] = max
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/offline-sessions")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<UserSession>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId}/service-account-user <br/>
        /// Get a user dedicated to the service account.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<User?> GetServiceAccountUserForClientAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/service-account-user")
                .GetJsonAsync<User>()
                .ConfigureAwait(false);

            return response;
        }

    }
}
