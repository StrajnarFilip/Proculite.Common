using System.IO;
using System.Security.Cryptography;

namespace Proculite.Common.Security.Cryptography
{
    public class SymmetricCryptoStream
    {
        private readonly SymmetricAlgorithm _symmetricAlgorithm;

        public SymmetricCryptoStream(SymmetricAlgorithm symmetricAlgorithm)
        {
            _symmetricAlgorithm = symmetricAlgorithm;
        }

        public void EncryptStream(Stream readFromStream, Stream writeToStream)
        {
            ICryptoTransform encryptor = _symmetricAlgorithm.CreateEncryptor();
            using (
                CryptoStream cryptoStream = new CryptoStream(
                    readFromStream,
                    encryptor,
                    CryptoStreamMode.Read
                )
            )
            {
                cryptoStream.CopyTo(writeToStream);
            }
        }

        public void DecryptStream(Stream readFromStream, Stream writeToStream)
        {
            ICryptoTransform decryptor = _symmetricAlgorithm.CreateDecryptor();
            using (
                CryptoStream cryptoStream = new CryptoStream(
                    readFromStream,
                    decryptor,
                    CryptoStreamMode.Read
                )
            )
            {
                cryptoStream.CopyTo(writeToStream);
            }
        }

        public byte[] EncryptBytes(byte[] source)
        {
            MemoryStream sourceBytes = new MemoryStream(source);
            MemoryStream encryptedBytes = new MemoryStream();
            EncryptStream(sourceBytes, encryptedBytes);

            return encryptedBytes.ToArray();
        }

        public byte[] DecryptBytes(byte[] source)
        {
            MemoryStream sourceBytes = new MemoryStream(source);
            MemoryStream decryptedBytes = new MemoryStream();
            DecryptStream(sourceBytes, decryptedBytes);

            return decryptedBytes.ToArray();
        }
    }
}
