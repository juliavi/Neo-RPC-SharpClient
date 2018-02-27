using System;

namespace Neo.KeyStore.Crypto
{
    public class DecryptionException : Exception
    {
        internal DecryptionException(string msg) : base(msg)
        {
        }
    }
}