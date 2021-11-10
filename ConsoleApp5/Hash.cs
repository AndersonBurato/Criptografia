using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Hash
    {
        public string HashValue(string stringToHash)
        {
            SHA512 hashService = SHA512.Create();

            byte[] hash = hashService.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));

            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
