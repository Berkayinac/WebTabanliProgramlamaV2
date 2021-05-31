using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Core.Utilities.Security.Hashing
{
    public class HashingHelper 
    {
        public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmacHash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmacHash.Key;
                passwordHash = hmacHash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmacHash = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var result = hmacHash.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (result[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
