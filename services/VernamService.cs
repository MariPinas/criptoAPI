using System;
using System.Text;

public class VernamService
{
    public string Encrypt(string plaintext, string key)
    {
        if (plaintext.Length != key.Length)
            throw new ArgumentException("Texto e chave precisam ter o mesmo tamanho.");

        StringBuilder ciphertext = new StringBuilder(plaintext.Length);

        for (int i = 0; i < plaintext.Length; i++)
        {
            char encryptedChar = (char)(plaintext[i] ^ key[i]);
            ciphertext.Append(encryptedChar);
        }

        return ciphertext.ToString();
    }

    public string Decrypt(string ciphertext, string key)
    {
        return Encrypt(ciphertext, key); // A operação e a mesma
    }
}