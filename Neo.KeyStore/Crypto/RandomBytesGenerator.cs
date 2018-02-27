using SecurityDriven.Inferno;

namespace Neo.KeyStore.Crypto
{
    public class RandomBytesGenerator : IRandomBytesGenerator
    {
        private static readonly CryptoRandom Random = new CryptoRandom();

        public byte[] GenerateRandomInitialisationVector()
        {
            return GenerateRandomBytes(16);
        }

        public byte[] GenerateRandomSalt()
        {
            return GenerateRandomBytes(32);
        }

        public byte[] GenerateRandomBytes(int size)
        {
            var bytes = new byte[size];
            Random.NextBytes(bytes);
            return bytes;
        }
    }
}