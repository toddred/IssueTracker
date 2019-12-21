using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BugtrackerIdentityService.Models
{
    public class User
    {
        public int Id { get; protected set; } 
        
        public string Name { get; protected set; }
        [EmailAddress]
        public string Email { get; protected set; }
        public  string Password { get; protected set; }
        public string Salt { get; protected set; }

        public User()
        {
            
        }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email.ToLower();
            Salt = CreateSalt();
            Password = HashPassword(password, Salt);
        }

        private string HashPassword(string unhashed, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: unhashed,
                salt: Convert.FromBase64CharArray(salt.ToCharArray(),0,128 /8),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

        }

        private string CreateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public bool IsCorrectPassword(string attempt)
        {
            if (HashPassword(attempt, Salt) == Password)
            {
                return true;
            }

            return false;
        }
    }
}