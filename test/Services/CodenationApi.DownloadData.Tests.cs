using System;
using System.Net;
using Codenation.CaesarCrypto.ConsoleApp.Models;
using Codenation.CaesarCrypto.ConsoleApp.Services;
using Moq;
using RestSharp;
using Xunit;

namespace Codenation.CaesarCrypto.Services.Tests
{
    public partial class CodenationsutTests
    {
        [Fact]
        public void DownloadData_WhenCalled_ExecuteOnlyOneApiCall()
        {
            // Arrange
            Mock<IRestResponse<CryptoAnswer>> restResponse =
                new Mock<IRestResponse<CryptoAnswer>>();
            restResponse
                .Setup(x => x.StatusCode)
                .Returns(HttpStatusCode.OK);

            restResponse
                .Setup(x => x.Data)
                .Returns(new CryptoAnswer());

            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient
                .Setup(x => x.Execute<CryptoAnswer>(
                    It.IsAny<IRestRequest>(),
                    Method.GET))
                .Returns(restResponse.Object);

            CodenationApi sut = null;

            // Act
            sut = new CodenationApi(restClient.Object);
            sut.DownloadData();

            // Assert
            restClient.Verify(x => x.Execute<CryptoAnswer>(
                It.IsAny<IRestRequest>(), Method.GET),
                Times.Once);
        }
    }
}
