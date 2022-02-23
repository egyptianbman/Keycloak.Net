using FluentAssertions;
using System.IO;
using Keycloak.Net.Model.Clients;
using Keycloak.Net.Shared.Json;
using Xunit;

namespace Keycloak.Net.Tests.Common.Extensions
{
    public class JsonExtensionsTest
    {
        [Fact]
        public void DeserializeJsonFromFile_ValidObject_ShouldSuccess()
        {
            // Arrange
            var jsonFile = Path.Combine("Client.json");

            // Act
            var actual = JsonExtensions.DeserializeJsonFromFile<Client>(jsonFile);

            // Assert
            actual.ClientId.Should().Be("clientAppId");
            actual.Name.Should().Be("clientApp");
            actual.AdminUrl.Should().Be("http://clientApp.example.com");
            actual.AlwaysDisplayInConsole.Should().Be(true);
            actual.Attributes.PkceCodeChallengeMethod.Should().Be(PkceCodeChallengeMethod.S256);
            actual.Attributes.RequestObjectRequired.Should().Be(RequestObjectRequired.RequestUri);
            actual.Attributes.SamlSignatureCanonicalizationMethod.Should().Be(SamlSignatureCanonicalizationMethod.None);
            actual.Attributes.SamlServerSignatureKeyInfoXmlSigKeyInfoKeyNameTransformer.Should().Be(SamlSignatureKeyName.None);
        }

        [Fact]
        public void SerializeJson_ValidObject_ShouldSuccess()
        {
            // Arrange
            var jsonFile = Path.Combine("Client.json");
            string expected;
            using (var sr = File.OpenText(jsonFile))
            {
                expected = sr.ReadToEnd();
            }
            var client = JsonExtensions.DeserializeJsonFromFile<Client>(jsonFile);

            // Act
            var actual = client.SerializeJson();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void DeserializeJson_ValidObject_ShouldSuccess()
        {
            // Arrange
            var jsonFile = Path.Combine("Client.json");
            using (var sr = File.OpenText(jsonFile))
            {
                sr.ReadToEnd();
            }

            var client = JsonExtensions.DeserializeJsonFromFile<Client>(jsonFile);
            var jsonString = client.SerializeJson();

            // Act
            var actual = jsonString.DeserializeJson<Client>();

            // Assert
            actual.Should().BeEquivalentTo(client);
            actual.Attributes.PkceCodeChallengeMethod.Should().Be(PkceCodeChallengeMethod.S256);
            actual.Attributes.RequestObjectRequired.Should().Be(RequestObjectRequired.RequestUri);
            actual.Attributes.SamlSignatureCanonicalizationMethod.Should().Be(SamlSignatureCanonicalizationMethod.None);
            actual.Attributes.SamlServerSignatureKeyInfoXmlSigKeyInfoKeyNameTransformer.Should().Be(SamlSignatureKeyName.None);
        }

        [Fact]
        public void IsValidJson_ValidJson_ShouldReturnTrue()
        {
            // Arrange
            var jsonFile = Path.Combine("Client.json");
            using (var sr = File.OpenText(jsonFile))
            {
                sr.ReadToEnd();
            }

            var applicationClaim = JsonExtensions.DeserializeJsonFromFile<Client>(jsonFile);
            var jsonString = applicationClaim.SerializeJson();

            // Act
            var result = jsonString.IsValidJson();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidJson_InvalidJson_ShouldReturnFalse()
        {
            // Arrange
            var testCases = new[]
            {
                string.Empty,
                "This is an invalid json",
                string.Join(',', "str1", "str2"),
                "{\"Str1\",\"Str2\"}",
                ToString()
            };

            // Act
            foreach (var testCase in testCases)
            {
                var result = testCase.IsValidJson();

                // Assert
                result.Should().BeFalse($"'{testCase}' should be false!");
            }
        }

        [Fact]
        public void Serialize_Deserialize_Enum_ShouldSuccess()
        {
            var status = PkceCodeChallengeMethod.S256;
            var serialized = status.SerializeJson();
            var deserialized = serialized.DeserializeJson<PkceCodeChallengeMethod>();

            serialized.Should().Contain(status.ToString());
            deserialized.Should().Be(status);
        }
    }
}
