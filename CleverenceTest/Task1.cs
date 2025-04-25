using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverenceTest
{
    public static class Task1
    {
        public static string Compression(string input)
        {
            input += " ";
            string output = string.Empty;
            int count = 1;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i+1])
                    count++;
                else
                {
                    if (count < 2)
                        output += input[i];
                    else
                    {
                        output += input[i];
                        output += count;
                        count = 1;
                    }
                }
            }

            return output;
        }
    }
}
