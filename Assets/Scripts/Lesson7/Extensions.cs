using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollBall
{
    public static class Extensions
    {
        public static int LetterCount(this string self)
        {
            return self.Length;
        }

        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}
