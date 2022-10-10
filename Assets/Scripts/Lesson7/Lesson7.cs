using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.Debug;
using System.Linq;

namespace RollBall
{
    public class Lesson7 : MonoBehaviour
    {


        void Start()
        {
            //1 In the docx file

            //2
            string myString = "Good morning GeekBrains";
            Log($"string: {myString} - {myString.LetterCount()} simbols");

            //3à
            List<int> listInt = new List<int>() {4, 1, 7, 3, 5, 5, 7, 8, 9, 3, 5, 3, 2, 1, 1, 0};
            GetEachCount(listInt);

            //3b
            List<string> listStr = new List<string>() { "Hello", "world", "world", "Hello", "GeekBrains", "world"};
            GetEachCount(listStr);

            //3c
            /*var names = from p in listStr
                            group p by p into g
                            select new { Name = g.Key, Count = g.Count() };*/

            var names = listStr
                    .GroupBy(p => p)
                    .Select(g => new { Name = g.Key, Count = g.Count() });

            StringBuilder str = new StringBuilder();
            foreach (var p in names)
            {
                str.Append($"element {p.Name} - {p.Count} count, ");
            }
            Log("3c: " + str);

        }

        private void GetEachCount<T>(List<T> list)
        {
            Dictionary<T, int> found = new Dictionary<T, int>();
            foreach (T val in list)
            {
                if (!found.ContainsKey(val))
                {
                    found[val] = 1;
                }
                else { found[val] = found[val]+1; }
            }

            StringBuilder str = new StringBuilder();
            foreach (KeyValuePair<T, int> p in found) 
            {
                str.Append($"element {p.Key} - {p.Value} count, ");
            }
            Log(str);
        }


    }
}
