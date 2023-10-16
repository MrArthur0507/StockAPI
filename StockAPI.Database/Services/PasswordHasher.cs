using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StockAPI.Database.Interfaces;

namespace StockAPI.Database.Services
{
    public class PasswordHasher:IPasswordHasher
    {
        private readonly IConfiguration _configuration;
        private readonly int _keySize;
        private readonly int _iterations;
        private readonly HashAlgorithmName _hashAlgorithm;
        public PasswordHasher(IConfiguration configuration)
        {
            _configuration = configuration;
            _keySize = int.Parse(_configuration.GetSection("AppSettings").GetSection("keySize").Value);
            _iterations = int.Parse(_configuration.GetSection("AppSettings").GetSection("iterations").Value);
            _hashAlgorithm = HashAlgorithmName.SHA512;
        }

        public string HashPassword(string password, out byte[] salt)
        {
            return Hashing(password, out salt);
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithm, _keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        private string Hashing(string password, out byte[] salt)
        {
            salt = new byte[_keySize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                _iterations,
                _hashAlgorithm,
                _keySize);

            // Use a proper logging mechanism instead of Console.WriteLine for logging the hash.
            Console.WriteLine(Convert.ToHexString(hash));
            return Convert.ToHexString(hash);
        }
    }
}
