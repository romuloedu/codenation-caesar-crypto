using System;
using System.Security.Cryptography;
using System.Text;

namespace Codenation.CaesarCrypto.ConsoleApp.Models
{
    public class CryptoService
    {
        public string UncryptMessage(CryptoAnswer answer)
        {
            // Objeto auxiliar na construção da string descriptografada.
            StringBuilder sb = new StringBuilder();

            // Converte a string em um array de caracteres.
            char[] letters = answer.EncryptedText
                .ToLower()
                .ToCharArray();

            foreach (char letter in letters)
            {
                char newLetter = letter;
                int letterNumericValue = (int)letter;

                // Verifica se a letra está dentro do limite de a a z.
                if (letterNumericValue >= 97 &&
                    letterNumericValue <= 122)
                {
                    newLetter = Convert.ToChar(letter - answer.NumSteps);
                }

                sb.Append(newLetter);
            }

            return sb.ToString();
        }

        public string CalculateHash(CryptoAnswer answer)
        {
            // Objeto auxiliar na construção da string descriptografada.
            StringBuilder sb = new StringBuilder();

            using (SHA1Managed sha = new SHA1Managed())
            {
                // Converte a string descriptografada em um array de bytes.
                byte[] encodedString = Encoding.Default
                    .GetBytes(answer.UncryptedText);

                // Calcula o hash, de fato, da string.
                byte[] hash = sha.ComputeHash(encodedString);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}