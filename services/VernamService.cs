using System;
using System.Text;

namespace criptoAPI.Services
{
    public class VernamService
    {
        public string Encrypt(string plaintext, string key)
        {
            if (plaintext.Length != key.Length)
                throw new ArgumentException("Texto e chave precisam ter o mesmo tamanho.");

            byte[] result = new byte[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
            {
                result[i] = (byte)(plaintext[i] ^ key[i]);
            }

            return Convert.ToBase64String(result);
        }

        public string Decrypt(string ciphertext, string key)
        {
            byte[] cypherBytes = Convert.FromBase64String(ciphertext);
            if (cypherBytes.Length != key.Length)
                throw new ArgumentException("Cypher e chave precisam ter o mesmo tamanho.");

            char[] result = new char[cypherBytes.Length];
            for (int i = 0; i < cypherBytes.Length; i++)
            {
                result[i] = (char)(cypherBytes[i] ^ key[i]);
            }
            return new string(result);
        }
    }
}