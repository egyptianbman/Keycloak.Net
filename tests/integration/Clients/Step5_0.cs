using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Model.ClientScopes;
using Keycloak.Net.Model.Common;
using Keycloak.Net.Model.Users;
using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Integration tests for 'Clients' management.
    /// </summary>
    [Collection(KeycloakClientTests.Clients)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class Step5_0
    {
        public Step5_0(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private static IEnumerable<ClientScope> _clientScopes;
        private static Credential _clientCredential;
        private static ClientScope _clientScope;
        private static ManagementPermission _managementPermission = new()
        {
            Enabled = true
        };

        #endregion

        [Fact, TestCasePriority(-10)]
        public async Task GetClientsAsync()
        {
            _fixture.Client = (await _keycloak.GetClientsAsync(_realm, _fixture.Client.ClientId))!.Single();
            _fixture.Client.Should().NotBeNull();
            _fixture.Client.Id.Should().NotBeNullOrEmpty();
            _fixture.Client.ClientId.Should().NotBeNullOrEmpty();

            _fixture.User = (await _keycloak.GetUsersAsync(_realm, username: _fixture.User.UserName)).Single();
        }

        [Fact]
        public async Task GetClientAsync()
        {
            var result = await _keycloak.GetClientByIdAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUserForServiceAccountAsync()
        {
            var result = await _keycloak.GetServiceAccountUserForClientAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateClientAndRetrieveClientIdAsync()
        {
            var client = new Client
            {
                ClientId = "newClient"
            };
            var result = await _keycloak.CreateClientAndRetrieveClientIdAsync(_realm, client);
            result.Should().NotBeNullOrEmpty();
            await _keycloak.DeleteClientByIdAsync(_realm, result);
        }

        [Fact, TestCasePriority(99)]
        public async Task UpdateClientAsync()
        {
            var result = await _keycloak.UpdateClientByIdAsync(_realm, _fixture.Client.Id!, _fixture.Client);
            result.Should().BeTrue();
        }

        [Fact(Skip="Use another client"), TestCasePriority(2)]
        public async Task GenerateClientSecretAsync()
        {
            _clientCredential = await _keycloak.GenerateClientSecretAsync(_realm, _fixture.Client.Id!);
            _clientCredential.Should().NotBeNull();
            _clientCredential.Value.Should().NotBeNullOrEmpty();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetClientSecretAsync()
        {
            var result = await _keycloak.GetClientSecretAsync(_realm, _fixture.Client.Id!);
            result.Should().BeEquivalentTo(_clientCredential);
        }

        [Fact]
        public async Task GetDefaultClientScopesAsync()
        {
            var result = (await _keycloak.GetDefaultClientScopesAsync(_realm, _fixture.Client.Id!)).ToList();
            result.Should().NotBeNullOrEmpty();
            _clientScope = result[0];
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateDefaultClientScopeAsync()
        {
            var result = await _keycloak.UpdateDefaultClientScopeAsync(_realm, _fixture.Client.Id!, _clientScope.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(4)]
        public async Task DeleteDefaultClientScopeAsync()
        {
            var result = await _keycloak.DeleteDefaultClientScopeAsync(_realm, _fixture.Client.Id!, _clientScope.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(3)]
        public async Task GenerateClientExampleAccessTokenAsync()
        {
            var result = await _keycloak.GenerateClientExampleAccessTokenAsync(_realm, _fixture.Client.Id!, userId: _fixture.User.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(3)]
        public async Task GenerateClientExampleIdTokenAsync()
        {
            var result = await _keycloak.GenerateClientExampleIdTokenAsync(_realm, _fixture.Client.Id!, userId: _fixture.User.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(3)]
        public async Task GenerateClientExampleUserInfoAsync()
        {
            var result = await _keycloak.GenerateClientExampleUserInfoAsync(_realm, _fixture.Client.Id!, userId: _fixture.User.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetProtocolMappersInTokenGenerationAsync()
        {
            var result = await _keycloak.GetProtocolMappersInTokenGenerationAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetClientGrantedScopeMappingsAsync()
        {
            // Realm container
            var result = await _keycloak.GetClientGrantedScopeMappingsAsync(_realm, _fixture.Client.Id!, _realm);
            result.Should().NotBeNull();

            // Client container
            result = await _keycloak.GetClientGrantedScopeMappingsAsync(_realm, _fixture.Client.Id!, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientNotGrantedScopeMappingsAsync()
        {
            // Realm container
            var result = await _keycloak.GetClientNotGrantedScopeMappingsAsync(_realm, _fixture.Client.Id!, _realm);
            result.Should().NotBeNull();

            // Client container
            result = await _keycloak.GetClientNotGrantedScopeMappingsAsync(_realm, _fixture.Client.Id!, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task GetClientProviderAsync()
        {
            var providerInstances = await _keycloak.GetIdentityProviderInstancesAsync(_realm);
            var providerInstanceId = providerInstances.FirstOrDefault()?.ProviderId;
            if (providerInstanceId != null)
            {
                var result = await _keycloak.GetClientProviderAsync(_realm, _fixture.Client.Id!, providerInstanceId);
                result.Should().NotBeNullOrEmpty();
            }
        }

        [Fact, TestCasePriority(3)]
        public async Task GetClientAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.GetClientAuthorizationPermissionsInitializedAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(2)]
        public async Task SetClientAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.SetClientAuthorizationPermissionsInitializedAsync(_realm, _fixture.Client.Id!, _managementPermission);
            result.Should().NotBeNull();
        }

        [Fact(Skip = "Not working")]
        public async Task RegisterClientClusterNodeAsync()
        {
            var result = await _keycloak.RegisterClientClusterNodeAsync(_realm, _fixture.Client.Id!, new Dictionary<string, object>{{ "node1", "value1"}});
            result.Should().BeTrue();
        }

        [Fact(Skip = "Not working")]
        public async Task UnregisterClientClusterNodeAsync()
        {
            var result = await _keycloak.UnregisterClientClusterNodeAsync(_realm, _fixture.Client.Id!, "node1");
            result.Should().BeTrue();
        }
        
        [Fact]
        public async Task GetClientOfflineSessionCountAsync()
        {
            var result = await _keycloak.GetClientOfflineSessionCountAsync(_realm, _fixture.Client.Id!);
            result.Should().Be(0);
        }

        [Fact]
        public async Task GetClientOfflineSessionsAsync()
        {
            var result = await _keycloak.GetClientOfflineSessionsAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetOptionalClientScopesAsync()
        {
            var result = await _keycloak.GetOptionalClientScopesAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateOptionalClientScopeAsync()
        {
            var result = await _keycloak.UpdateOptionalClientScopeAsync(_realm, _fixture.Client.Id!, _clientScope.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(4)]
        public async Task DeleteOptionalClientScopeAsync()
        {
            var result = await _keycloak.DeleteOptionalClientScopeAsync(_realm, _fixture.Client.Id!, _clientScope.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(4)]
        public async Task PushClientRevocationPolicyAsync()
        {
            var result = await _keycloak.PushClientRevocationPolicyAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GenerateClientRegistrationAccessTokenAsync()
        {
            var result = await _keycloak.GenerateClientRegistrationAccessTokenAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetClientSessionCountAsync()
        {
            var result = await _keycloak.GetClientSessionCountAsync(_realm, _fixture.Client.Id!);
            result.Should().Be(0);
        }

        [Fact]
        public async Task TestClientClusterNodesAvailableAsync()
        {
            var result = await _keycloak.TestClientClusterNodesAvailableAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientUserSessionsAsync()
        {
            var result = await _keycloak.GetClientUserSessionsAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact(Skip = "Not working")]
        public async Task GetResourcesOwnedByClientAsync()
        {
            var result = await _keycloak.GetResourcesOwnedByClientAsync(_realm, _fixture.Client.Id!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetClientPolicies()
        {
            var result = await _keycloak.GetClientPolicies(_realm);
            result.Should().NotBeNull();
            result.Policies.Should().ContainEquivalentOf(_fixture.ClientPolicy,
                opt => opt.Using(new IgnoreNullMembersInExpectation(_fixture.ClientPolicy)));
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateClientPolicies()
        {
            var result = await _keycloak.UpdateClientPolicies(
                _realm,
                new ClientPolicies { Policies = new[] { _fixture.ClientPolicy } }
            );
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetClientProfiles()
        {
            var result = await _keycloak.GetClientProfiles(_realm);
            result.Should().NotBeNull();
            result.Profiles.Should().ContainEquivalentOf(_fixture.ClientProfile,
                opt => opt.Using(new IgnoreNullMembersInExpectation(_fixture.ClientProfile)));
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateClientProfiles()
        {
            var result =
                await _keycloak.UpdateClientProfiles(_realm,
                    new ClientProfiles { Profiles = new[] { _fixture.ClientProfile } });
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetClientSessionStatsAsync()
        {
            var result = await _keycloak.GetClientSessionStatsAsync(_realm);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCredentialRegistrators()
        {
            var result = await _keycloak.GetCredentialRegistrators(_realm);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRealmClientScopesAsync()
        {
            _clientScopes = await _keycloak.GetRealmClientScopesAsync(_realm);
            _clientScopes.Should().NotBeNullOrEmpty();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetRealmDefaultClientScopesAsync()
        {
            var emailScope = _clientScopes.First(s => s.Name == "email");
            var result = (await _keycloak.GetRealmDefaultClientScopesAsync(_realm)).ToList();
            result.Should().NotBeNullOrEmpty();
            result.Should().ContainEquivalentOf(emailScope, opt => opt
                .Including(s => s.Id)
                .Including(s => s.Name)
            );
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateRealmDefaultClientScopeAsync()
        {
            var emailScope = _clientScopes.First(s => s.Name == "email");
            var result = await _keycloak.UpdateRealmDefaultClientScopeAsync(_realm, emailScope.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(1)]
        public async Task DeleteRealmDefaultClientScopeAsync()
        {
            var emailScope = _clientScopes.First(s => s.Name == "email");
            var result = await _keycloak.DeleteRealmDefaultClientScopeAsync(_realm, emailScope.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetRealmOptionalClientScopesAsync()
        {
            var addressScope = _clientScopes.First(s => s.Name == "address");
            var result = (await _keycloak.GetRealmOptionalClientScopesAsync(_realm)).ToList();

            result.Should().NotBeNull();
            result.Should().ContainEquivalentOf(addressScope, opt => opt
                .Including(s => s.Id)
                .Including(s => s.Name)
            );
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateRealmOptionalClientScopeAsync()
        {
            var addressScope = _clientScopes.First(s => s.Name == "address");
            var result = await _keycloak.UpdateRealmOptionalClientScopeAsync(_realm, addressScope.Id!);

            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(1)]
        public async Task DeleteRealmOptionalClientScopeAsync()
        {
            var addressScope = _clientScopes.First(s => s.Name == "address");
            var result = await _keycloak.DeleteRealmOptionalClientScopeAsync(_realm, addressScope.Id!);

            result.Should().BeTrue();
        }

    }
}
