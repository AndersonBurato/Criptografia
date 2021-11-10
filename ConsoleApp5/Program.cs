using System;
using System.Security.Cryptography;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash hash = new Hash();

            var text = hash.HashValue(Console.ReadLine());

            Console.WriteLine(text);
        }
    }
}
