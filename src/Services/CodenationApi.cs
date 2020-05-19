using Codenation.CaesarCrypto.ConsoleApp.Models;
using Codenation.CaesarCrypto.ConsoleApp.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Codenation.CaesarCrypto.ConsoleApp.Services
{
    public class CodenationApi
    {
        private readonly IRestClient _client;
        private readonly CodenationSecrets _codenationSecrets;
        public IRestClient Client => _client;

        public CodenationApi(IRestClient client = null)
        {
            _client = CodenationApiFactory.Create(client);

            // Adiciona o suporte ao serializer Newtonsoft.
            _client.UseNewtonsoftJson();

            var services = ServiceProviderBuilder
                .GetServiceProvider();

            _codenationSecrets = services
                .GetRequiredService<IOptions<CodenationSecrets>>()
                .Value;
        }

        public CryptoAnswer DownloadData()
        {
            if (CryptoAnswer.HasFile)
                return CryptoAnswer.RecreateObject();

            var request = new RestRequest("/generate-data",
                DataFormat.Json);

            request.AddQueryParameter("token",
                _codenationSecrets.Token);

            IRestResponse<CryptoAnswer> response = _client
                .Execute<CryptoAnswer>(request);

            return response.Data;
        }

        public string UploadData(string path)
        {
            var request = new RestRequest("/submit-solution",
                DataFormat.Json);

            request.AddQueryParameter("token",
                _codenationSecrets.Token);

            request.AddFile("answer", path,
                "multipart/form-data");

            IRestResponse response = _client.Post(request);

            return response.Content;
        }
    }
}