using System;
using System.Text;

namespace RollBall
{
    public static class Crypto
    {
        public static string Crypt(string text, int key = 7)
        {
            StringBuilder result = new StringBuilder();
            foreach (var simbol in text)
            {
                result.Append((char)(simbol + key));
            }
            return result.ToString();
        }

        public static string DeCrypt(string text, int key = 7)
        {
            StringBuilder result = new StringBuilder();
            foreach (var simbol in text)
            {
                result.Append((char)(simbol - key));
            }
            return result.ToString();
        }
    }
}
