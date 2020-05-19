using System;
using Codenation.CaesarCrypto.ConsoleApp.Models;
using Codenation.CaesarCrypto.ConsoleApp.Services;

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
            CryptoAnswer answer = api.DownloadData();

            Console.WriteLine("Salvando o answer.json original...");

            // Salva o arquivo com o conteúdo original.
            answer.SaveFile();

            // Cria a instância da classe de criptografia.
            CryptoService cryptoService = new CryptoService();

            Console.WriteLine("Descriptografando a mensagem...");

            // Descriptografa a mensagem recebida.
            answer.UncryptedText = cryptoService.UncryptMessage(answer);

            Console.WriteLine("Calculando o hash da mensagem...");

            // Calcula o hash da mensagem recebida.
            answer.CryptographSummary = cryptoService.CalculateHash(answer);

            Console.WriteLine("Salvando o arquivo modificado...");

            // Salva o resultado modificado no arquivo.
            answer.SaveFile();

            // Envia o arquivo para a API da Codenation.
            // string response = api.UploadData(answer.FileName);

            // Console.WriteLine($"Resultado do envio: {response}");
        }
    }
}
