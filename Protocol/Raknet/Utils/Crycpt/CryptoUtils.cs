using ATRI.Protocol.Raknet.Utils.Cryptography;
using Org.BouncyCastle.Crypto;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATRI.Protocol.Protocol.Raknet.Utils.Crycpt
{
    public static class CryptoUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] Encrypt(ReadOnlyMemory<byte> payload, CryptoContext cryptoContext)
        {
            // hash
            int hashPoolLen = 8 + payload.Length + cryptoContext.Key.Length;
            var hashBufferPooled = ArrayPool<byte>.Shared.Rent(hashPoolLen);
            Span<byte> hashBuffer = hashBufferPooled.AsSpan();
            BitConverter.GetBytes(Interlocked.Increment(ref cryptoContext.SendCounter)).CopyTo(hashBuffer.Slice(0, 8));
            payload.Span.CopyTo(hashBuffer.Slice(8));
            cryptoContext.Key.CopyTo(hashBuffer.Slice(8 + payload.Length));
            using var hasher = SHA256.Create();
            Span<byte> validationCheckSum = hasher.ComputeHash(hashBufferPooled, 0, hashPoolLen).AsSpan(0, 8);
            ArrayPool<byte>.Shared.Return(hashBufferPooled);

            IBufferedCipher cipher = cryptoContext.Encryptor;
            var encrypted = new byte[payload.Length + 8];
            int length = cipher.ProcessBytes(payload.ToArray(), encrypted, 0);
            cipher.ProcessBytes(validationCheckSum.ToArray(), encrypted, length);

            return encrypted;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyMemory<byte> Decrypt(ReadOnlyMemory<byte> payload, CryptoContext cryptoContext)
        {
            IBufferedCipher cipher = cryptoContext.Decryptor;

            ReadOnlyMemory<byte> clear = cipher.ProcessBytes(payload.ToArray());
            Console.WriteLine(Convert.ToHexString(clear.ToArray()));
            //TODO: Verify hash!
            return clear.Slice(0, clear.Length - 8);
        }
    }
}
