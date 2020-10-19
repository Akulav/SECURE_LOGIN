using System;
using System.Security.Cryptography;
using System.Text;

namespace Hashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string salt = "WlptaaWGLMjFdA==";
            string hash = "aIJzUhcJxRLToXfMH7ozYX8UbUc622GqgUse78hlnOA=";
            string input = Console.ReadLine();
            if (Generator.AreEqual(input, hash, salt))
            {
                Console.WriteLine("Corect");
            }

            else { Console.WriteLine("Gresit"); }
            Console.ReadLine();
        }
    }


    public class Generator
    {
        public static string CreateSalt(int size)
        {

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool AreEqual(string plainTextInput, string hashedInput, string salt)
        {
            string newHashedPin = GenerateHash(plainTextInput, salt);
            return newHashedPin.Equals(hashedInput);
        }
    }
}
