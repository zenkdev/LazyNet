using System;
using System.IO;
using System.Security.Cryptography;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public static class CryptoHelper
    {
        // ReSharper disable once InconsistentNaming
        static readonly byte[] IV = { 218, 70, 127, 168, 189, 69, 68, 107, 23, 6, 41, 100, 227, 188, 49, 228 };
        static readonly byte[] Key = { 83, 57, 113, 113, 171, 1, 33, 17, 6, 180, 191, 192, 237, 234, 120, 217, 152, 182, 161, 69, 13, 157, 201, 70, 222, 139, 178, 205, 187, 110, 102, 15 };

        public static string Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            try
            {
                // Create a new instance of the RijndaelManaged
                // class.  This generates a new key and initialization 
                // vector (IV).
                //var myRijndael = new RijndaelManaged();

                // Encrypt the string to an array of bytes.
                var encrypted = EncryptStringToBytes(input, Key, IV);
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                WinHelper.LogException(ex);
            }

            return null;
        }

        public static string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            try
            {
                var encrypted = Convert.FromBase64String(input);
                // Decrypt the bytes to a string.
                var roundtrip = DecryptStringFromBytes(encrypted, Key, IV);

                return roundtrip;
            }
            catch (Exception ex)
            {
                WinHelper.LogException(ex);
            }

            return null;
        }

        static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            byte[] encrypted;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}