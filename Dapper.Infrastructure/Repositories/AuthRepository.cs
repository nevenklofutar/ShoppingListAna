using Contracts;
using Entities;
using Entities.Commands;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        // TODO: fix implementations 
        private readonly IConfiguration configuration;

        public AuthRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<User> Login(UserForLogin userForLogin)
        {
            var sql = "SELECT * FROM Users WHERE Username = @Username";
            User user = null;
            using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Username = userForLogin.Username });
            }

            var userVerified = VerifyPassword(user.PasswordSalt, user.PasswordHash, userForLogin.Password);

            if (userVerified)
                return user;

            return null;
        }

        public async Task Register(UserForRegister userForRegister)
        {
            try { 
                var salt = GenerateSalt();
                var saltedPassword = GeneratePasswordHash(userForRegister.Password, salt);
                userForRegister.PasswordSalt = salt;
                userForRegister.PasswordHash = saltedPassword;
                userForRegister.CreatedOn = DateTime.Now;

                var sql = "INSERT INTO Users (FirstName,LastName,Email,Username,PasswordHash,PasswordSalt,CreatedOn) " +
                    " VALUES (@FirstName,@LastName,@Email,@Username,@PasswordHash,@PasswordSalt,@CreatedOn)";
                using (var connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    await connection.ExecuteAsync(sql, userForRegister);
                }
            } catch (Exception ex) {
                throw;
            }
        }

        private byte[] GenerateSalt() {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[16];
            rng.GetBytes(salt);
            //return Convert.ToBase64String(salt);
            return salt;
        }

        private byte[] GeneratePasswordHash(string password, byte[] salt)
        {
            try
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var byteResult = new Rfc2898DeriveBytes(passwordBytes, salt, 10000);
                //return Convert.ToBase64String(byteResult.GetBytes(24));
                return byteResult.GetBytes(16);
            } catch (Exception ex) {
                throw;
            }
        }

        private bool VerifyPassword(byte[] hashedUserSalt, byte[] hashedUserPassword, string inputPassword) {
            
            var inputHashedPassword = GeneratePasswordHash(inputPassword, hashedUserSalt);
            return StructuralComparisons.StructuralEqualityComparer.Equals(hashedUserPassword, inputHashedPassword);
        }

    }
}
