using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Symmetric
    {
        private const string Key = "minhaChaveSegura";
        public string IV;

        public string Encrypt(string stringToCipher)
        {
            Aes cipher = Aes.Create();
            cipher.Key = Encoding.UTF8.GetBytes(Key);

            IV = Convert.ToBase64String(cipher.IV);

            ICryptoTransform cryptTransform = cipher.CreateEncryptor();

            var byteToCipher = Encoding.UTF8.GetBytes(stringToCipher);
            var cipherText = cryptTransform.TransformFinalBlock(byteToCipher, 0, byteToCipher.Length);

            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string cipherToString)
        {
            Aes cipher = Aes.Create();
            cipher.Key = Encoding.UTF8.GetBytes(Key);
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            var cipherBytes = Convert.FromBase64String(cipherToString);
            var plainText = cryptoTransform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(plainText);
        }
    }
}
