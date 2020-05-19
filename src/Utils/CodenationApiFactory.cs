using Codenation.CaesarCrypto.ConsoleApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Codenation.CaesarCrypto.ConsoleApp.Utils
{
    public static class CodenationApiFactory
    {
        public static IRestClient Create(IRestClient client)
        {
            if (client != null) return client;

            client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps");

            return client;
        }
    }
}