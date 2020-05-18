using System;
using Codenation.CaesarCrypto.ConsoleApp.Models;

namespace Codenation.CaesarCrypto.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria o serviço que encapsula a api.
            CodenationApi api = new CodenationApi();

            Console.WriteLine("Realizando o download dos dados...");

            // Faz o download do desafio.
            CryptoAnswer response = api.DownloadData();

            Console.WriteLine("Salvando o answer.json origina...");

            // Salva o arquivo com o conteúdo original.
            response.SaveFile();

            // Cria a instância da classe de criptografia.
            CryptoService cryptoService = new CryptoService();

            Console.WriteLine("Descriptografando a mensagem...");

            // Descriptografa a mensagem recebida.
            response.UncryptedText = cryptoService.UncryptMessage(response);

            Console.WriteLine("Calculando o hash da mensagem...");

            // Calcula o hash da mensagem recebida.
            response.CryptographSummary = cryptoService.CalculateHash(response);

            Console.WriteLine("Salvando o arquivo modificado...");

            // Salva o resultado modificado no arquivo.
            response.SaveFile();

            Console.WriteLine("Processamento concluído.");
        }
    }
}
