using System;
using System.Security.Cryptography;
using System.Text;

namespace Nivel1.Shared
{
    public static class HashCreator
    {
        public static string Create(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ts + privateKey + publicKey);

            var gerador = MD5.Create();

            byte[] bytesHash = gerador.ComputeHash(bytes);

            return BitConverter.ToString(bytesHash)
                    .ToLower()
                    .Replace("-", String.Empty);
        }
    }
}