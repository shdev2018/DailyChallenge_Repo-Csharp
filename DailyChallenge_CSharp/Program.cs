using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyChallenge_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = prob_09_07_2020(new List<int> { 1, 2, 0 });
            #region OldProbs
            //var result = prob_07_07_2020(new List<int> { 3, 2, 1 });
            //var result = prob_06_07_2020(new List<int> { 10, 15, 3, 7}, 17);
            #endregion
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// Given an array of integers, find the first missing positive integer in linear time and constant space. 
        /// In other words, find the lowest positive integer that does not exist in the array. 
        /// The array can contain duplicates and negative numbers as well.
        private static int? prob_09_07_2020(IList<int> array)
        {
            array = array.OrderBy(i => i).ToList();
            int? last = null;
            foreach (var num in array)
            {
                if (last != null && num > 0)
                {
                    if (num != last && num > (last + 1))
                    {
                        if (last + 1 > 0)
                        {
                            return last + 1;
                        }
                        if (num > 1)
                        {
                            return 1;
                        }
                    }
                }
                last = num;
            }
            if (array.Count > 0)
            {
                return array.LastOrDefault() + 1;
            }
            return null;
        }
        // Completed in 00:09:56

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
