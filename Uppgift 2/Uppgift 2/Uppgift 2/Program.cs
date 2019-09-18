using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv en mening: ");
            String inStr = Console.ReadLine();
            //tar bort extra mellanslag med trim
            inStr.Trim(' ');

            int wordCount = 1;
            //räkna antalet ord
            for (int i = 0; i < inStr.Length; i++)
            {
                if (inStr[i] == ' ')
                {
                    wordCount++;
                }


            }

            Console.WriteLine("Det är {0} ord ", wordCount);

            string[] words = new string[wordCount];

            int found = 0;
            int start = 0;

            for (int i = 0; i < wordCount; i++)
            {
                found = inStr.IndexOf(' ', start);
                if (found == -1)
                {
                    found = inStr.Length;
                }
                words[i] = inStr.Substring(start, found - start);
                start = found + 1;
            }
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));

            for (int i = 0; i < wordCount; i++)
            {
                Console.WriteLine("{0} ({1})", words[i], words[i].Length);
            }
            for (int i = wordCount - 1; i >= 0; i--)
            {
                Console.WriteLine("{0} ({1})", words[i], words[i].Length);
            }

        }
    }
}
