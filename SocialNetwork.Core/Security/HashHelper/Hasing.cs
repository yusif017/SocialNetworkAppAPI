using System.Security.Cryptography;
using System.Text;

namespace SocialNetwork.Core.Security.HashHelper
{
    public static class Hasing
    {
        public static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using HMACSHA512 hash = new();
            passwordSalt = hash.Key;
            passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using HMACSHA512 hash = new(passwordSalt);
            var hashing = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (hashing[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
