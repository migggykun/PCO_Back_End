using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PCO_Back_End.Models.Accounts.SaltHash
{
    public class DataCryptography
    {


        /// <summary>
        /// Generates SHA256 encrypted string
        /// </summary>
        /// <param name="rawData"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string GetSha256Hash(string rawData, string salt)
        {
            string hashWithSalt = rawData + salt;
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(hashWithSalt));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Generates random salt values.
        /// </summary>
        /// <returns></returns>
        public string CreateSalt()
        {
            int saltSize = 10;
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[saltSize];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }


    }
}