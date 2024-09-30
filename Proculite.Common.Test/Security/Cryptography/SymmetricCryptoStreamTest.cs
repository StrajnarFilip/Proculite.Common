namespace Proculite.Common.Test.Security.Cryptography
{
    using System.Security.Cryptography;
    using Proculite.Common.Security.Cryptography;

    public class SymmetricCryptoStreamTest
    {
        [Fact]
        public void InputEncryptedDecrypted_EqualOutput()
        {
            Aes aes = SimpleAes.Create(
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
            );

            byte[] original = [1];
            SymmetricCryptoStream symmetricCryptoStream = new SymmetricCryptoStream(aes);

            byte[] result = symmetricCryptoStream.DecryptBytes(
                symmetricCryptoStream.EncryptBytes(original)
            );
            Assert.Equal(result[0], original[0]);
            Assert.Single(result);
        }
    }
}
