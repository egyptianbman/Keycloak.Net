using FluentAssertions;
using Keycloak.Net.Shared.Extensions;
using System;
using Xunit;

namespace Keycloak.Net.Tests.Common.Extensions
{
    public class ExceptionExtensionsTest
    {
        [Fact]
        public void FlattenError_ShouldThrowInnerException()
        {
            // Arrange
            var ex1 = new InvalidOperationException(nameof(InvalidOperationException));
            var ex2 = new InvalidCastException(nameof(InvalidCastException), ex1);
            var ex3 = new Exception("OuterException", ex2);

            // Act
            var exceptionMessage = ex3.FlattenError();

            // Assert
            exceptionMessage.Should().Contain("OuterException");
            exceptionMessage.Should().Contain(nameof(InvalidCastException));
            exceptionMessage.Should().Contain(nameof(InvalidOperationException));
        }
    }
}
