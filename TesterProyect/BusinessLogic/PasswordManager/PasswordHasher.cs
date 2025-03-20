using System.Security.Cryptography;

namespace TesterProyect.BusinessLogic.PasswordManager
{
    public static class PasswordHasher
    {
        public class HashResult
        {
            public required string Hash { get; set; }
            public required byte[] Salt { get; set; }
        }

        public static HashResult HashPassword(string password)
        {
            byte[] salt;
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt = new byte[16]);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return new HashResult 
            { 
                Hash = Convert.ToBase64String(hashBytes), 
                Salt = salt 
            };
        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword, byte[] salt)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] storedHash = new byte[20];
            Array.Copy(hashBytes, 16, storedHash, 0, 20);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000, HashAlgorithmName.SHA256);
            byte[] testHash = pbkdf2.GetBytes(20);

            return storedHash.SequenceEqual(testHash);
        }
    }
}
