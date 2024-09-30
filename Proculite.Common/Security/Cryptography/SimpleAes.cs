using System.Security.Cryptography;

namespace Proculite.Common.Security.Cryptography
{
    public static class SimpleAes
    {
        public static Aes Create(byte[] key, byte[] iv, CipherMode cipherMode = CipherMode.CBC)
        {
            Aes aes = Aes.Create();
            aes.IV = iv;
            aes.Key = key;
            aes.Mode = cipherMode;

            return aes;
        }

        public static SymmetricCryptoStream CreateCryptoStream(
            byte[] key,
            byte[] iv,
            CipherMode cipherMode = CipherMode.CBC
        )
        {
            Aes aes = Create(key, iv, cipherMode);
            return new SymmetricCryptoStream(aes);
        }
    }
}
