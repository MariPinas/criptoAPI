using System;
using System.Text;
using System.Linq;

namespace criptoAPI.Services
{
    public class VernamService
    {
        public string Encrypt(string plaintext, string key)
        {
            if (plaintext.Length != key.Length)
                throw new ArgumentException("Texto e chave precisam ter o mesmo tamanho.");

            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] result = new byte[plaintextBytes.Length];

            for (int i = 0; i < plaintextBytes.Length; i++)
            {
                result[i] = (byte)(plaintextBytes[i] ^ keyBytes[i]);
            }

            var binaryString = string.Join("", result.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

            return binaryString;
        }

        public string Decrypt(string binaryCipherText, string key)
        {
            if (binaryCipherText.Length % 8 != 0)
                throw new ArgumentException("Texto cifrado inválido. Deve ser múltiplo de 8 bits.");

            int byteCount = binaryCipherText.Length / 8;
            byte[] cipherBytes = new byte[byteCount];

            for (int i = 0; i < byteCount; i++)
            {
                string byteString = binaryCipherText.Substring(i * 8, 8);
                cipherBytes[i] = Convert.ToByte(byteString, 2);
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            if (cipherBytes.Length != keyBytes.Length)
                throw new ArgumentException("Texto e chave precisam ter o mesmo tamanho.");

            byte[] result = new byte[cipherBytes.Length];

            for (int i = 0; i < cipherBytes.Length; i++)
            {
                result[i] = (byte)(cipherBytes[i] ^ keyBytes[i]);
            }

            return Encoding.UTF8.GetString(result);
        }
    }
}
