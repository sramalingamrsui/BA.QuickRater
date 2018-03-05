using System;
using System.Configuration;
using System.Security.Cryptography;

namespace RSUI.BA.Rating.Data.Hash
{
    public class Authenticator
    {
        public static string GenerateHash(byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            string key = ConfigurationManager.AppSettings["SystemUserGUID"];
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(key);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);

            byte[] hashmessage = hmacsha1.ComputeHash(input);

            return  ByteToString(hashmessage);

        }
        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);

        }

        public bool InputIsUntampered(byte[] input, string hash)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new ArgumentException("hash must be provided");
            }

            return GenerateHash(input).Equals(hash);
            
        }
    }
}