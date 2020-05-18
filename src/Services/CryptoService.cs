using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Codenation.CaesarCrypto.ConsoleApp.Models
{
    public class CryptoService
    {
        public CryptoService()
        {
        }

        public string DecryptMessage(CryptoAnswer answer)
        {
            return null;
        }

        public string CalculateHash(CryptoAnswer answer)
        {
            return null;
        }
    }
}