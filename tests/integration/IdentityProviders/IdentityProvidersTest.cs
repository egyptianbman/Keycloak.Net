using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Keycloak.Net.Model.IdentityProviders;
using Keycloak.Net.Shared.Json;
using Xunit;

namespace Keycloak.Net.Tests
{
    [Collection(KeycloakClientTests.IdentityProviders)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class IdentityProvidersTest
    {
        public IdentityProvidersTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        private static IList<IdentityProvider> _identityProviders;

        #endregion

        [Fact, TestCasePriority(-11)]
        public async Task AddIdentityProviderAsync()
        {
            var result = await _keycloak.AddIdentityProviderAsync(_realm, _fixture.IdentityProvider);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(2)]
        public async Task UpdateIdentityProviderAsync()
        {
            var result = await _keycloak.UpdateIdentityProviderAsync(_realm, _fixture.IdentityProvider.Alias!, _fixture.IdentityProvider);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetIdentityProviderInstancesAsync()
        {
            _identityProviders = (await _keycloak.GetIdentityProviderInstancesAsync(_realm)).ToList();
            _identityProviders.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetIdentityProviderAsync()
        {
            var result = await _keycloak.GetIdentityProviderAsync(_realm, _fixture.IdentityProvider.Alias!);
            result.Should().NotBeNull();
            _fixture.IdentityProvider = result;
        }

        [Fact]
        public async Task GetIdentityProviderByProviderIdAsync()
        {
            var result = await _keycloak.GetIdentityProviderByProviderIdAsync(_realm, _fixture.IdentityProvider.ProviderId!);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(2)]
        public async Task SetIdentityProviderAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.SetIdentityProviderAuthorizationPermissionsInitializedAsync(_realm, _fixture.IdentityProvider.Alias!, _fixture.ManagementPermission);
            result.Should().NotBeNull();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetIdentityProviderAuthorizationPermissionsInitializedAsync()
        {
            var result = await _keycloak.GetIdentityProviderAuthorizationPermissionsInitializedAsync(_realm, _fixture.IdentityProvider.Alias!);
            result.Should().NotBeNull();
        }

        [Fact(Skip = "Not working"), TestCasePriority(3)]
        public async Task GetIdentityProviderMapperTypesAsync()
        {
            var result = await _keycloak.GetIdentityProviderMapperTypesAsync(_realm, _fixture.IdentityProvider.Alias!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestCasePriority(2)]
        public async Task AddIdentityProviderMapperAsync()
        {
            var result = await _keycloak.AddIdentityProviderMapperAsync(_realm, _fixture.IdentityProvider.Alias!, _fixture.IdentityProviderMapper);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetIdentityProviderMappersAsync()
        {
            var result = await _keycloak.GetIdentityProviderMappersAsync(_realm, _fixture.IdentityProvider.Alias!);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact, TestCasePriority(3)]
        public async Task GetIdentityProviderMapperByIdAsync()
        {
            var result = (await _keycloak.GetIdentityProviderMapperByIdAsync(_realm, _fixture.IdentityProvider.Alias!, _fixture.IdentityProviderMapper.Id!)).ToList();
            result.Should().NotBeNull();
            _fixture.IdentityProviderMapper = result.First();
        }

        [Fact, TestCasePriority(3)]
        public async Task UpdateIdentityProviderMapperAsync()
        {
            var result = await _keycloak.UpdateIdentityProviderMapperAsync(_realm, _fixture.IdentityProvider.Alias!, _fixture.IdentityProviderMapper.Id!, _fixture.IdentityProviderMapper);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(4)]
        public async Task DeleteIdentityProviderMapperAsync()
        {
            var result = await _keycloak.DeleteIdentityProviderMapperAsync(_realm, _fixture.IdentityProvider.Alias!, _fixture.IdentityProviderMapper.Id!);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task ExportIdentityProviderPublicBrokerConfigurationAsync()
        {
            var result = await _keycloak.ExportIdentityProviderPublicBrokerConfigurationAsync(_realm, _fixture.IdentityProvider.Alias!);
            result.Should().BeTrue();
        }

        [Fact, TestCasePriority(10)]
        public async Task DeleteIdentityProviderAsync()
        {
            var result = await _keycloak.DeleteIdentityProviderAsync(_realm, _fixture.IdentityProvider.Alias!);
            result.Should().BeTrue();
        }

        [Fact(Skip = "Not working"), TestCasePriority(11)]
        public async Task ImportIdentityProviderAsync()
        {
            var result = await _keycloak.ImportIdentityProviderAsync(_realm, _fixture.IdentityProvider.SerializeJson());
            result.Should().NotBeNull();
        }

        [Fact]
        public void TestJson_IdentityProviderMapper()
        {
            var item = new IdentityProviderMapper
            {
                Id = "id",
                Name = "name",
                IdentityProviderAlias = "alias",
                Config = new AttributeImporter
                {
                    SyncMode = IdentityProviderSyncMode.Inherit,
                    JsonField = "json",
                    UserAttribute = "userAttr"
                },
                MapperType = IdentityProviderMapperType.AttributeImporter
            };
            var json = item.SerializeJson();
            var itemObj = json.DeserializeJson<IdentityProviderMapper>();

            itemObj.Should().BeEquivalentTo(item);
        }
    }
}