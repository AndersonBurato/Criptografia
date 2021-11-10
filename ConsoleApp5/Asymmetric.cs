using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
    public class Asymmetric
    {
        private const string privateKey = "<RSAKeyValue><Modulus>yJ/QHskucASptyOtaSkvLZaMRjMA8EUHzCo8I0Uxr5SysFb6j/EzjL0BqJlPxJ1BPoaZxMbcIvyPVQHwuitTaMp293sTfWxfIfvSD4LhZDkJAyygR6tmKgVAlP1KNpwux0u79LYKPXsKVdqM3rWgtibE/ad+vjsX1STUBpdpySE=</Modulus><Exponent>AQAB</Exponent><P>4wwyvmifbZkXhEJL2XzFjH/xGxFTE5aBhreWJyt4U9R8DKp+1ghMJAKZ+f7yd1yGLgexTqobCX0SQBp6UcYoew==</P><Q>4jULDAU9JkQnVv0lgtWje2U8wOt2YVdHjBcIx9/WAsNUu0n0zjn9OkBizJBoqdakRQLtk94XLhf9nQw1aZfYEw==</Q><DP>v+eSiE/j2P3Z26cxdw036C5HuuokvtyqdBR+LHNYi/qAMzB0bjGrMZClVqF/jRW+L+++lM/AdH+rSlVW6AFGOw==</DP><DQ>p5CJXV8oHAeSaLLfLZraHlcw+OuzZooD2vdZLs5VtvhA9Pfk2ztDpPn69fPnRCBW0TRJDycOXruwx7w6eLzddw==</DQ><InverseQ>Aq5MXECWjsZL/H9/p8DrNPXbF0Gph+BLB7dAhTS3yKQh/zgcRI3am30vuoG/bXKd5RcRG1tNTY+Xl+qCCdP0mg==</InverseQ><D>MDboB14GAPm957t1Q16YbfZOQ9iiExwj4ZcM2NUaOb4cq3BbyxgGcX5C1cfyeafpNCOY9MdtxCK6N4290p/y7UE9RiEDzQH7RSBg3A0cM5X9rJgyknR4vaPGa4HE8IE45ImK+qPRUANSjT/WnzaelQJeecQQFFoLpWmyaLt9QXk=</D></RSAKeyValue>";
        private const string publicKey = "<RSAKeyValue><Modulus>yJ/QHskucASptyOtaSkvLZaMRjMA8EUHzCo8I0Uxr5SysFb6j/EzjL0BqJlPxJ1BPoaZxMbcIvyPVQHwuitTaMp293sTfWxfIfvSD4LhZDkJAyygR6tmKgVAlP1KNpwux0u79LYKPXsKVdqM3rWgtibE/ad+vjsX1STUBpdpySE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public string Encrypt(string stringToEncrypt)
        {
            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();

            cipher.FromXmlString(publicKey);

            var data = Encoding.UTF8.GetBytes(stringToEncrypt);
            var cipherText = cipher.Encrypt(data, true);

            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string stringToDecrypt)
        {
            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();

            cipher.FromXmlString(privateKey);

            var original = cipher.Decrypt(Convert.FromBase64String(stringToDecrypt), true);

            return Encoding.UTF8.GetString(original);
        }
    }
}
