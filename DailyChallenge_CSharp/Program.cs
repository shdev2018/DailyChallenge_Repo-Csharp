using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DailyChallenge_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = prob_07_07_2020(new List<int> { 3, 2, 1 });
            Console.WriteLine(JsonConvert.SerializeObject(result));

            //var result = prob_06_07_2020(new List<int> { 10, 15, 3, 7}, 17);
        }

        /// Given an array of integers, return a new array such that each element at index i of the new 
        /// array is the product of all the numbers in the original array except the one at i.
        private static IList<int> prob_07_07_2020(IList<int> array)
        {
            List<int> newArray = new List<int>();
            int j;
            for (int i = 0; i < array.Count; i++)
            {
                int temp = 0;
                for (j = 0; j < array.Count; j++)
                {
                    if (i != j)
                    {
                        if (temp == 0)
                        {
                            temp = array[j];
                        }
                        else
                        {
                            temp = temp * array[j];
                        }
                    }
                }
                if (j == i)
                {
                    newArray.Add(array[j]);
                }
                else
                {
                    newArray.Add(temp);
                }
            }
            return newArray;
        }
        // Complete on 00:11:20

        /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
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
