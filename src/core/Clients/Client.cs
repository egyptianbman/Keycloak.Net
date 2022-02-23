using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Model.Clients;


namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        /// <summary>
        /// POST /{realm}/clients <br/>
        /// Create a new client. Client’s client_id must be unique!
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="client">client representation</param>
        public async Task<bool> CreateClientAsync(string realm, Client client)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients")
                .PostJsonAsync(client)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// POST /{realm}/clients <br/>
        /// Create a new client. Client’s client_id must be unique!
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="client">client representation</param>
        /// <returns>client id for the created client.</returns>
        public async Task<string> CreateClientAndRetrieveClientIdAsync(string realm, Client client)
        {
            var response = (await GetBaseUrl()
                    .AppendPathSegment($"/admin/realms/{realm}/clients")
                    .PostJsonAsync(client)
                    .ConfigureAwait(false))
                .ResponseMessage;

            var locationPathAndQuery = response.Headers.Location!.PathAndQuery;
            var clientId = response.IsSuccessStatusCode
                ? locationPathAndQuery.Substring(locationPathAndQuery.LastIndexOf("/", StringComparison.Ordinal) + 1)
                : null;
            return clientId!;
        }

        /// <summary>
        /// GET /{realm}/clients
        /// Get clients belonging to the realm. Returns a list of clients belonging to the realm.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">filter by clientId (not id!)</param>
        /// <param name="first">the first result</param>
        /// <param name="max">the max results to return</param>
        /// <param name="q"></param>
        /// <param name="search">whether this is a search query or a getClientById query</param>
        /// <param name="viewableOnly">filter clients that cannot be viewed in full by admin</param>
        public async Task<IEnumerable<Client>?> GetClientsAsync(
            string realm,
            string? clientId = null,
            int? first = null,
            int? max = null,
            string? q = null,
            bool? search = null,
            bool? viewableOnly = null)
        {
            var queryParams = new Dictionary<string, object?>
            {
                [nameof(clientId)] = clientId,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(q)] = q,
                [nameof(search)] = search,
                [nameof(viewableOnly)] = viewableOnly
            };

            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Client>>()
                .ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// GET /{realm}/clients/{clientId} <br/>
        /// Get representation of the client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<Client?> GetClientByIdAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}")
                .GetJsonAsync<Client>()
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// PUT /{realm}/clients/{clientId} <br/>
        /// Update the client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        /// <param name="client"></param>
        public async Task<bool> UpdateClientByIdAsync(string realm, string clientId, Client client)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}")
                .PutJsonAsync(client)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        /// <summary>
        /// DELETE /{realm}/clients/{clientId} <br/>
        /// Delete the client.
        /// </summary>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="clientId">id of client (not <see cref="Client.ClientId"/>)</param>
        public async Task<bool> DeleteClientByIdAsync(string realm, string clientId)
        {
            var response = await GetBaseUrl()
                .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

    }
}
