using System.Linq;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Cleanup for the integration test
    /// </summary>
    [Collection(KeycloakClientTests.Cleanup)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class Step9_0
    {
        public Step9_0(KeycloakFixture fixture)
        {
            _fixture = fixture;
            _keycloak = fixture.AdminCliClient;

            _realm = fixture.Realm._Realm;
            _masterRealm = fixture.MasterRealm;
        }

        #region Properties

        private readonly KeycloakFixture _fixture;
        private readonly KeycloakClient _keycloak;
        private readonly string _realm;
        private readonly string _masterRealm;

        #endregion

        [Fact, TestCasePriority(10)]
        public async Task DeleteRoleByNameAsync_Realm()
        {
            var result = await _keycloak.DeleteRoleByNameAsync(_realm, _fixture.Role.Name!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(94)]
        public async Task DeleteClientAsync()
        {
            _fixture.Client = (await _keycloak.GetClientsAsync(_realm, clientId: _fixture.Client.ClientId))!.Single();
            var result = await _keycloak.DeleteClientByIdAsync(_realm, _fixture.Client.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(95)]
        public async Task DeleteUserGroupAsync()
        {
            _fixture.User = (await _keycloak.GetUsersAsync(_realm, username: _fixture.User.UserName))!.Single();
            _fixture.Group = (await _keycloak.GetGroupsAsync(_realm)).Single(g => g.Name!.Equals(_fixture.Group.Name));
            var result = await _keycloak.DeleteUserGroupAsync(_realm, _fixture.User.Id!, _fixture.Group.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(96)]
        public async Task DeleteGroupAsync()
        {
            var result = await _keycloak.DeleteGroupByIdAsync(_realm, _fixture.Group.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(97)]
        public async Task DisableUserCredentialsAsync()
        {
            var result = await _keycloak.DisableUserCredentialsAsync(_realm, _fixture.User.Id!, new[] { "password" });
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(98)]
        public async Task DeleteUserCredential()
        {
            _fixture.Credential = (await _keycloak.GetUserCredentials(_realm, _fixture.User.Id!))!.Single();
            var result = await _keycloak.DeleteUserCredential(_realm, _fixture.User.Id!, _fixture.Credential.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(99)]
        public async Task DeleteUserAsync()
        {
            var result = await _keycloak.DeleteUserByIdAsync(_realm, _fixture.User.Id!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(100)]
        public async Task DeleteRealmAsync()
        {
            var result = await _keycloak.DeleteRealmAsync(_masterRealm, _fixture.Realm._Realm!);
            result.Should().BeTrue();
        }
    }
}
