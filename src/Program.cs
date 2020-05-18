using System;
using Codenation.CaesarCrypto.ConsoleApp.Models;

namespace Codenation.CaesarCrypto.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria o serviço que encapsula a api.
            var api = new CodenationApi();

            // Faz o download do desafio.
            var response = api.DownloadFile();

            // Salva o resultado no arquivo answer.json.
            response.SaveFile();

            Console.ReadLine();
        }
    }
}
