using System.IO;
using Newtonsoft.Json;

namespace Codenation.CaesarCrypto.ConsoleApp.Models
{
    public class CryptoAnswer
    {
        [JsonProperty(PropertyName = "numero_casas")]
        public int NumSteps
        {
            get;
            private set;
        }

        [JsonProperty("token")]
        public string Token
        {
            get;
            private set;
        }

        [JsonProperty(PropertyName = "cifrado")]
        public string EncryptedText
        {
            get;
            private set;
        }

        [JsonProperty("decifrado")]
        public string UncryptedText
        {
            get;
            set;
        }

        [JsonProperty("resumo_criptografico")]
        public string CryptographSummary
        {
            get;
            set;
        }

        public void SaveFile()
        {
            using (TextWriter writer = new StreamWriter("answer.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                // Informa ao serializer para indentar o resultado.
                serializer.Formatting = Formatting.Indented;

                serializer.Serialize(writer, this);
            };
        }
    }
}