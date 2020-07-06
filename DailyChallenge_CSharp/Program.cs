using System;
using System.Collections.Generic;

namespace DailyChallenge_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = prob_06_07_2020(new List<int> { 10, 15, 3, 7}, 17);
            Console.WriteLine(result);
        }

        // Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
        private static bool prob_06_07_2020 (IList<int> list, int k)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int n1 = list[i];
                for (int j = 0; j < list.Count; j++)
                {
                    int n2 = list[j];
                    if (i != j && n1 + n2 == k)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // Completed in 00:04:37
    }
}
