using System.Threading.Tasks;
using FluentAssertions;
using Flurl.Http;
using Keycloak.Net.Model.Root;
using Xunit;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Integration tests for Oidc 'Authentication'.
    /// </summary>
    [Collection(KeycloakClientTests.Authentication)]
    [TestCaseOrderer("Keycloak.Net.Tests.TestCasePriorityOrderer", "Keycloak.Net.Tests")]
    public class OidcTest
    {
        public OidcTest(KeycloakFixture fixture)
        {
            _keycloak = fixture.TestNoAuthClient;
            _fixture = fixture;
            _realm = fixture.Realm._Realm;
        }

        #region Properties

        private readonly KeycloakClient _keycloak;
        private readonly KeycloakFixture _fixture;
        private readonly string _realm;

        #endregion

        [Fact]
        public async Task GetOpenIdConfigurationAsync()
        {
            var result = await _keycloak.GetOpenIdConfigurationAsync(_realm);
            result.Issuer!.AbsoluteUri.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetJwksAsync()
        {
            var result = await _keycloak.GetJwksAsync(_realm);
            result.Should().NotBeNull();
            result.Keys.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public async Task EndsessionAsync()
        {
            var result = await _keycloak.EndsessionAsync(_realm);
            result.Should().BeTrue();
        }

        /// <summary>
        /// Test keycloak client no authentication.
        /// </summary>
        [Fact]
        public async Task GetUserInfoAsync_NoAuth_ShouldReturnBadRequest()
        {
            var act = async () => await _keycloak.GetUserinfoAsync(_realm);
            await act.Should().ThrowAsync<KeycloakException>().WithMessage($"*invalid_request: Token not provided*")
                .WithInnerException(typeof(FlurlHttpException)).WithMessage("*400 (Bad Request)*");
        }

        /// <summary>
        /// Test keycloak client "Client Credentials" flow authentication by getting userinfo.
        /// </summary>
        [Fact]
        public async Task GetUserInfoAsync_ClientCredentialsFlow()
        {
            var keycloak = _fixture.TestClient;
            var result = await keycloak.GetUserinfoAsync(_realm);
            result.Should().NotBeNullOrEmpty();
            result[JwtClaimTypes.PreferredUserName].Should().Be("service-account-testclient");
        }

        /// <summary>
        /// Test keycloak client "Password" flow authentication by getting userinfo.
        /// </summary>
        [Fact]
        public async Task GetUserInfoAsync_PasswordFlow()
        {
            var keycloak = _fixture.AdminCliClient;
            var result = await keycloak.GetUserinfoAsync(_fixture.MasterRealm);
            result.Should().NotBeNullOrEmpty();
            result[JwtClaimTypes.PreferredUserName].Should().Be("admin");
        }
        
        [Fact]
        public async Task GetUserInfoAsync_InvalidRealm_ShouldReturnUnauthorized()
        {
            var keycloak = _fixture.AdminCliClient;
            var act = async () => await keycloak.GetUserinfoAsync(_realm);
            await act.Should().ThrowAsync<KeycloakException>().WithMessage($"*invalid_token: Token verification failed*")
                .WithInnerException(typeof(FlurlHttpException)).WithMessage("*401 (Unauthorized)*");
        }

        /// <summary>
        /// Test keycloak client "Bearer" authentication by getting userinfo.
        /// </summary>
        [Fact]
        public async Task GetUserInfoAsync_BearerToken()
        {
            var rawToken = await _keycloak.GetPasswordToken(_realm, "admin-cli", _fixture.User.UserName, _fixture.Credential.Value!);
            var keycloak = new KeycloakClient(_fixture.Url, () => rawToken.AccessToken);
            var result = await keycloak.GetUserinfoAsync(_realm);
            result.Should().NotBeNullOrEmpty();
            result[JwtClaimTypes.PreferredUserName].Should().Be("admin");
        }

        /// <summary>
        /// Test keycloak client "Bearer" authentication by getting userinfo.
        /// </summary>
        [Fact]
        public async Task GetUserInfoAsync_BearerTokenAsync()
        {
            var getTokenAsync = async () => (await _keycloak.GetClientCredentialsToken(_realm, _fixture.Client.ClientId, _fixture.Client.Secret!)).AccessToken;
            var keycloak = new KeycloakClient(_fixture.Url, getTokenAsync);
            var result = await keycloak.GetUserinfoAsync(_realm);
            result.Should().NotBeNullOrEmpty();
            result[JwtClaimTypes.PreferredUserName].Should().Be("service-account-testclient");
        }

        [Fact]
        public async Task GetClientCredentialsToken()
        {
            var result = await _keycloak.GetClientCredentialsToken(_realm, _fixture.Client.ClientId, _fixture.Client.Secret!);
            result.Should().NotBeNull();
            result.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetPasswordToken()
        {
            var result = await _keycloak.GetPasswordToken(_realm, "admin-cli", _fixture.User.UserName, _fixture.Credential.Value!);
            result.Should().NotBeNull();
            result.AccessToken.Should().NotBeNullOrEmpty();
        }
    }
}
