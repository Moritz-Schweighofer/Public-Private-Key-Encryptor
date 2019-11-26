using System;
using System.Security.Cryptography;
using System.Text;

namespace Public_Private_Key_Encryptor
{
    public class RSAController
    {
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        public RSAController()
        {
            //Pass
        }

        public static string Encrypt(string data, string _public_key)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(_public_key);
                var dataToEncrypt = _encoder.GetBytes(data);

                var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false);
                var encryptedString = Convert.ToBase64String(encryptedByteArray);

                return encryptedString;
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error With Encrypting the Password: " + ex.Message);
                return "";
            }
        }

        public static string Decrypt(string data, string _private_key)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
                var dataByte = Convert.FromBase64String(data);

                rsa.FromXmlString(_private_key);
                var decryptedByte = rsa.Decrypt(dataByte, false);

                return _encoder.GetString(decryptedByte);
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error With Decrypting the Password: " + ex.Message);
                return "";
            }
        }
    }
}