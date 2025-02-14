﻿using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Keycloak.Net.Tests
{
    [Collection(KeycloakClientTests.ClientScopes)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class ClientScopesTest
    {
        public ClientScopesTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        #endregion

        [Fact, TestCasePriority(-11)]
        public async Task CreateClientScopeAsync()
        {
            var result = await _keycloak.CreateClientScopeAsync(_realm, _fixture.ClientScope);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(-10)]
        public async Task GetClientScopesAsync()
        {
            var result = (await _keycloak.GetClientScopesAsync(_realm)).Single(c => c.Name!.Equals(_fixture.ClientScope.Name));
            result.Should().NotBeNull();
            _fixture.ClientScope = result;
        }

        [Fact, TestCasePriority(3)]
        public async Task GetClientScopeAsync()
        {
            var result = await _keycloak.GetClientScopeAsync(_realm, _fixture.ClientScope.Id!);
            result.Should().BeEquivalentTo(_fixture.ClientScope,
                opt => opt.Using(new IgnoreNullMembersInExpectation(_fixture.ClientScope)));
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateClientScopeAsync()
        {
            var result = await _keycloak.UpdateClientScopeAsync(_realm, _fixture.ClientScope.Id!, _fixture.ClientScope);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(4)]
        public async Task DeleteClientScopeAsync()
        {
            var result = await _keycloak.DeleteClientScopeAsync(_realm, _fixture.ClientScope.Id!);
            result.Should().BeTrue();
        }
    }
}
