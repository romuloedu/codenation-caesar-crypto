using System;
using Codenation.CaesarCrypto.ConsoleApp.Services;
using Moq;
using RestSharp;
using Xunit;

namespace Codenation.CaesarCrypto.Services.Tests
{
    public partial class CodenationsutTests
    {
        [Fact]
        public void Constructor_WhenInstanceIsCreatedWithoutParam_ReturnsAnRestClient()
        {
            // Arrange
            CodenationApi sut = null;

            // Act
            sut = new CodenationApi();

            // Assert
            Assert.NotNull(sut.Client);
        }

        [Fact]
        public void Constructor_WhenInstanceIsCreatedWithoutParam_ReturnsAnRestClientWithBaseUrlSetted()
        {
            // Arrange
            CodenationApi sut = null;
            string baseUrl = "https://api.codenation.dev/v1/challenge/dev-ps";

            // Act
            sut = new CodenationApi();

            // Assert
            Assert.Equal(baseUrl, sut.Client.BaseUrl.OriginalString);
        }

        [Fact]
        public void Constructor_WhenInstanceIsCreatedWithParam_ReturnsAnRestClientPropertyWithSameInstance()
        {
            // Arrange
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            CodenationApi sut = null;

            // Act
            sut = new CodenationApi(restClient.Object);

            // Assert
            Assert.Same(restClient.Object, sut.Client);
        }
    }
}
