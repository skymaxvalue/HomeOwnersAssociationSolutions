using Microsoft.AspNetCore.Http;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class CryptoHelper
    {
        private static readonly int KeySize = 256; // AES key size in bits
        private static readonly int Iterations = 10000; // Number of PBKDF2 iterations
        private static readonly int SaltSize = 16; // Size of the salt in bytes
        private static readonly int IvSize = 16; // Size of the IV in bytes (AES block size)
        private static readonly string password = "ParkingSolution"; // password
        private static string token = "ParkingSolution" + "☻" + DateTime.Now.ToString();
        private static int tokenExpiry = 30;


        private static readonly HashSet<byte[]> tokenset = new HashSet<byte[]>();



        // Derives a key and IV from the given password and salt
        private static (byte[] Key, byte[] IV) DeriveKeyAndIV(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] key = pbkdf2.GetBytes(KeySize / 8);
                byte[] iv = pbkdf2.GetBytes(IvSize);
                return (key, iv);
            }
        }

        // Encrypts plaintext using AES with the given password
        public static byte[] Encrypt(string plainText, string password)
        {
            byte[] salt;
            byte[] iv;
            byte[] key;
            byte[] encrypted;

            using (Aes aes = Aes.Create())
            {
                salt = GenerateRandomBytes(SaltSize);
                (key, iv) = DeriveKeyAndIV(password, salt);

                aes.Key = key;
                aes.IV = iv;

                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }
                            encrypted = ms.ToArray();
                        }
                    }
                }
            }

            // Prepend salt and IV to the encrypted data
            byte[] result = new byte[SaltSize + IvSize + encrypted.Length];
            Buffer.BlockCopy(salt, 0, result, 0, SaltSize);
            Buffer.BlockCopy(iv, 0, result, SaltSize, IvSize);
            Buffer.BlockCopy(encrypted, 0, result, SaltSize + IvSize, encrypted.Length);

            return result;
        }

        // Decrypts ciphertext using AES with the given password
        public static string Decrypt(byte[] cipherText, string password)
        {
            byte[] salt = new byte[SaltSize];
            byte[] iv = new byte[IvSize];
            byte[] encrypted = new byte[cipherText.Length - SaltSize - IvSize];

            // Extract salt, IV, and encrypted data
            Buffer.BlockCopy(cipherText, 0, salt, 0, SaltSize);
            Buffer.BlockCopy(cipherText, SaltSize, iv, 0, IvSize);
            Buffer.BlockCopy(cipherText, SaltSize + IvSize, encrypted, 0, encrypted.Length);

            (byte[] key, _) = DeriveKeyAndIV(password, salt);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream(encrypted))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        // Generates random bytes of the given size
        private static byte[] GenerateRandomBytes(int size)
        {
            byte[] bytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }






        public static List<string> DecryptParkingUser(HashSet<byte[]> clienttokens)
        {
            try
            {
                var empty = new HashSet<byte[]> { new byte[0] };
                List<DateTime> DecrypedTokenList = new List<DateTime>();
                DateTime dateTime1 = DateTime.Now;

                foreach (var token in clienttokens)
                {
                    var dt = Decrypt(token, password);
                    if (dt != null)
                    {
                        string dateString = (dt.Split("☻")[1]);
                        string format = "yyyy-MM-dd HH:mm:ss";
                        DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
                        DecrypedTokenList.Add(dateTime);
                    }

                }

                TimeSpan difference = DecrypedTokenList[0].Subtract(DecrypedTokenList[1]);
                double minutesDifference = difference.TotalMinutes;
                if (minutesDifference <= tokenExpiry)
                {
                    var recenttoken = Encrypt(token, password);
                    AddSet(recenttoken);
                    return HashSetToBase64String(tokenset);
                }
                else
                {
                    return null;
                }


                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<string> EncryptParkingUser()
        {
            try
            {
                byte[] encrypted = Encrypt(token, password);
                
                AddSet(encrypted);//Repeat for token1
                AddSet(encrypted);//Repeat for token2

                return HashSetToBase64String(tokenset);
                 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void AddSet(byte[] newSet)
        {
            byte[] firstItem = new byte[0];
            if (tokenset.Count >= 2)
            {
                List<byte[]> list = new List<byte[]>(tokenset);
                firstItem = list[0];
                // Remove the oldest set to maintain only two sets
                tokenset.Remove(firstItem);
            }

            tokenset.Add(newSet);
        }

        public static HashSet<byte[]> GetSets()
        {
            return tokenset;
        }
        static List<string> HashSetToBase64String(HashSet<byte[]> hashSet)
        {
            List<string> base64Strings = new List<string>();

            foreach (var byteArray in hashSet)
            {
                string base64String = Convert.ToBase64String(byteArray);
                base64Strings.Add(base64String);
            }

            return base64Strings;
        }

      public  static  HashSet<byte[]> Base64StringToHashSet(string base64String)
        {
            HashSet<byte[]> hashSet = new HashSet<byte[]>();

            // Split the Base64 string by the separator used when encoding (e.g., comma)
            string[] base64ArrayStrings = base64String.Split(',');

            foreach (string base64Segment in base64ArrayStrings)
            {
                // Decode each Base64 string back to a byte array
                byte[] byteArray = Convert.FromBase64String(base64Segment);
                hashSet.Add(byteArray);
            }

            return hashSet;
        }
       


    }
}

  
