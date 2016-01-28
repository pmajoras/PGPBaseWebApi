using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.Cryptography
{
    /// <summary>
    /// 
    /// </summary>
    public static class PasswordHasher
    {
        // 24 = 192 bits
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 10101;

        /// <summary>
        /// Computes the hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="hashByteSize">Size of the hash byte.</param>
        /// <returns></returns>
        public static string ComputeHash(string password, string salt, int iterations = HasingIterationsCount, int hashByteSize = HashByteSize)
        {
            return Convert.ToBase64String(ComputeHash(password, Convert.FromBase64String(salt), iterations, hashByteSize));
        }

        /// <summary>
        /// Computes the hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="hashByteSize">Size of the hash byte.</param>
        /// <returns></returns>
        public static byte[] ComputeHash(string password, byte[] salt, int iterations = HasingIterationsCount, int hashByteSize = HashByteSize)
        {
            Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt);
            hashGenerator.IterationCount = iterations;
            return hashGenerator.GetBytes(hashByteSize);
        }

        /// <summary>
        /// Generates the salt.
        /// </summary>
        /// <param name="saltByteSize">Size of the salt byte.</param>
        /// <returns></returns>
        public static string GenerateSalt(int saltByteSize = SaltByteSize)
        {
            RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltByteSize];
            saltGenerator.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Verifies the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns></returns>
        public static bool VerifyPassword(string password, string passwordSalt, string passwordHash)
        {
            return VerifyPassword(password,
                Convert.FromBase64String(passwordSalt),
                Convert.FromBase64String(passwordHash));
        }

        /// <summary>
        /// Verifies the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns></returns>
        public static bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            byte[] computedHash = ComputeHash(password, passwordSalt);
            return AreHashesEqual(computedHash, passwordHash);
        }

        /// <summary>
        /// Ares the hashes equal.
        /// </summary>
        /// <param name="firstHash">The first hash.</param>
        /// <param name="secondHash">The second hash.</param>
        /// <returns></returns>
        private static bool AreHashesEqual(byte[] firstHash, byte[] secondHash)
        {
            int minHashLenght = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
            var xor = firstHash.Length ^ secondHash.Length;
            for (int i = 0; i < minHashLenght; i++)
                xor |= firstHash[i] ^ secondHash[i];
            return 0 == xor;
        }
    }
}
