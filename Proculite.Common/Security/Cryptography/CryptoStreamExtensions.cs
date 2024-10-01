using System.IO;
using System.Security.Cryptography;

namespace Proculite.Common.Security.Cryptography
{
    public static class CryptoStreamExtensions
    {
        public static BinaryReader AesEncryptStream(
            this Stream readFromStream,
            byte[] aesKey,
            byte[] aesIv,
            CipherMode cipherMode = CipherMode.CBC
        )
        {
            Aes aes = SimpleAes.Create(aesKey, aesIv, cipherMode);
            ICryptoTransform encryptor = aes.CreateEncryptor();
            return readFromStream.CryptoReadStream(encryptor);
        }

        public static BinaryReader AesDecryptStream(
            this Stream readFromStream,
            byte[] aesKey,
            byte[] aesIv,
            CipherMode cipherMode = CipherMode.CBC
        )
        {
            Aes aes = SimpleAes.Create(aesKey, aesIv, cipherMode);
            ICryptoTransform encryptor = aes.CreateDecryptor();
            return readFromStream.CryptoReadStream(encryptor);
        }

        public static BinaryReader CryptoReadStream(
            this Stream readFromStream,
            ICryptoTransform encryptor
        )
        {
            return new BinaryReader(
                new CryptoStream(readFromStream, encryptor, CryptoStreamMode.Read)
            );
        }

        public static BinaryWriter CryptoWriteStream(
            this Stream writeToStream,
            ICryptoTransform encryptor
        )
        {
            return new BinaryWriter(
                new CryptoStream(writeToStream, encryptor, CryptoStreamMode.Write)
            );
        }
    }
}
