using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Codenation.CaesarCrypto.ConsoleApp.Models
{
    public class CryptoAnswer
    {
        private const string FILE_NAME = "answer.json";

        [JsonProperty("numero_casas")]
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

        [JsonIgnore]
        public string FileName => FILE_NAME;

        public static bool HasFile => File.Exists(FILE_NAME);

        public static CryptoAnswer RecreateObject()
        {
            CryptoAnswer result = null;

            using (TextReader reader = new StreamReader(FILE_NAME))
            {
                result = JsonConvert.DeserializeObject<CryptoAnswer>(
                    reader.ReadToEnd());
            };

            return result;
        }

        public void SaveFile()
        {
            using (TextWriter writer = new StreamWriter(FILE_NAME,
                false, Encoding.Default))
            {
                JsonSerializer serializer = new JsonSerializer();

                // Informa ao serializer para indentar o resultado.
                serializer.Formatting = Formatting.Indented;

                serializer.Serialize(writer, this);
            };
        }
    }
}