using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_3
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

            Array.Sort(words);
            int[] ocrword = new int[wordCount];
            int[] ocrsort = new int[wordCount];
            int equalsCounter = 1;
            for (int i = 0; i < wordCount - 1; i++)
            {
                if (words[i].Equals(words[i + 1])){
                    equalsCounter++;
                } else
                {
                    Console.WriteLine("{0} ({1})", words[i], equalsCounter);
                    ocrword[i] = equalsCounter;
                    ocrsort[i] = equalsCounter;
                    equalsCounter = 1;
                }
            }
            Console.WriteLine("{0} ({1})\n", words[words.Length - 1], equalsCounter);
            ocrword[wordCount - 1] = equalsCounter;
            ocrsort[wordCount - 1] = equalsCounter;

            Array.Sort(ocrsort);
            for (int i = wordCount - 1; i >= 0; i--)
            {
                if (ocrsort[i] != 0)
                {
                    for (int j = 0; j < wordCount; j++)
                    {
                        if (ocrword[j] == ocrsort[i])
                        {
                            Console.WriteLine("{0} ({1})", words[j], ocrword[j]);
                            ocrword[j] = 0;
                        }
                    }
                }
            }
        }
    }
}
