using System.Security.Cryptography;

namespace Proculite.Common.Security.Cryptography
{
    public static class SimpleAes
    {
        public static Aes Create(byte[] key, byte[] iv)
        {
            Aes aes = Aes.Create();
            aes.IV = iv;
            aes.Key = key;

            return aes;
        }
    }
}
