using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Codenation.CaesarCrypto.ConsoleApp.Models
{
    public class CodenationApi
    {
        private IRestClient _client;
        private CodenationSecrets _codenationSecrets;

        public CodenationApi()
        {
            _client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps");

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