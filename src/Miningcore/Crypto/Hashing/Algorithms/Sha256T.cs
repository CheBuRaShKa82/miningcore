using System.Security.Cryptography;
using Miningcore.Contracts;

namespace Miningcore.Crypto.Hashing.Algorithms;

/// <summary>
/// Sha-256 triple round
/// </summary>
[Identifier("sha256t")]
public class Sha256T : IHashAlgorithm
{
    public void Digest(ReadOnlySpan<byte> data, Span<byte> result, params object[] extra)
    {
        Contract.Requires<ArgumentException>(result.Length >= 32);

        using(var hasher = SHA256.Create())
        {
            hasher.TryComputeHash(data, result, out _);
            hasher.TryComputeHash(result, result, out _);
            hasher.TryComputeHash(result, result, out _);
        }
    }
}
