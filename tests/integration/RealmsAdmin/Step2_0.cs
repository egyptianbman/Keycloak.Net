using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Flurl.Http;
using Keycloak.Net.Model.RealmsAdmin;
using Keycloak.Net.Model.Root;
using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Integration tests for 'Realms Admin' management.
    /// </summary>
    [Collection(KeycloakClientTests.RealmsAdmin)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class Step2_0
    {
        public Step2_0(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private static RealmEventsConfig _realmEventsConfig;

        #endregion

        [Fact, TestCasePriority(-1)]
        public async Task GetRealmAsync()
        {
            var result = await _keycloak.GetRealmAsync(_realm);
            result.Should().NotBeNull();
            _fixture.Realm = result;
        }

        [Fact, TestCasePriority(-1)]
        public async Task GetRealmAsync_NotExists_ShouldThrowException()
        {
            var act = async () => await _keycloak.GetRealmAsync("realmNotExists");
            await act.Should().ThrowAsync<KeycloakException>().WithMessage("*Realm not found*")
                .WithInnerException(typeof(FlurlHttpException)).WithMessage("*Call failed with status code 404 (Not Found)*");
        }

        [Fact]
        public async Task GetRealmsAsync()
        {
            var result = (await _keycloak.GetRealmsAsync(_realm))!.ToList();
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestCasePriority(-2)]
        public async Task UpdateRealmAsync()
        {
            var result = await _keycloak.UpdateRealmAsync(_realm, _fixture.Realm);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetAdminEventsAsync()
        {
            var result = await _keycloak.GetAdminEventsAsync(_realm);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ClearKeysCacheAsync()
        {
            var result = await _keycloak.ClearKeysCacheAsync(_realm);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task ClearRealmCacheAsync()
        {
            var result = await _keycloak.ClearRealmCacheAsync(_realm);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetEventsAsync()
        {
            var result = await _keycloak.GetEventsAsync(_realm);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRealmEventsProviderConfigurationAsync()
        {
            _realmEventsConfig = await _keycloak.GetRealmEventsProviderConfigurationAsync(_realm);
            _realmEventsConfig.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateRealmEventsProviderConfigurationAsync()
        {
            var result = await _keycloak.UpdateRealmEventsProviderConfigurationAsync(_realm, _realmEventsConfig);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetRealmGroupByPathAsync()
        {
            var result = await _keycloak.GetRealmGroupByPathAsync(_realm, _fixture.Group.Path!);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetRealmLocalization()
        {
            var result = await _keycloak.GetRealmLocalization(_realm);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task RealmPartialExportAsync()
        {
            var result = await _keycloak.RealmPartialExportAsync(_realm);
            result.Should().NotBeNull();
        }
    }
}