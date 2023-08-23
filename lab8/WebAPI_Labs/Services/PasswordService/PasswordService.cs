using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace WebAPI_Labs.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        private readonly int iterations = 10001;
        public string HashPassword(string password)
        {
            // Generate a salt
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash the password
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: iterations,
                numBytesRequested: 256 / 8));

            // Return the salt and hashed password
            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Extract the salt and hashed password from the stored hash
            var parts = storedHash.Split('.');
            var salt = Convert.FromBase64String(parts[0]);
            var hashedPassword = parts[1];

            // Hash the entered password
            string enteredHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: iterations,
                numBytesRequested: 256 / 8));

            // Compare the entered hash with the stored hash
            return enteredHash == hashedPassword;
        }
    }

}
