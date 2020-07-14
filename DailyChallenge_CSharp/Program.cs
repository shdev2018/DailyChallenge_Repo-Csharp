using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyChallenge_CSharp
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            var result = prob_14_07_2020(new List<int>{ 5, 1, 1, 5 } );
            #region OldProbs
            //var result = prob_13_07_2020(326283);
            //var result = prob_11_07_2020();
            //var result = prob_09_07_2020(new List<int> { 1, 2, 0 });
            //var result = prob_07_07_2020(new List<int> { 3, 2, 1 });
            //var result = prob_06_07_2020(new List<int> { 10, 15, 3, 7}, 17);
            #endregion
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        /// Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. 
        /// Numbers can be 0 or negative.
        private static int? prob_14_07_2020(IList<int> list)
        {
            int first = 0;
            int second = 0;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                int sum = Math.Max(list[i] + second, first);
                second = first;
                first = sum;
            }

            return first;
        }
        // Completed in 00:09:34

        /// Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
        /// For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
        /// You can assume that the messages are decodable.For example, '001' is not allowed.
        private static int prob_13_07_2020(long encoded)
        {
            int result = 0;

            string inputStr = encoded.ToString();

            for (int i = 0; i < inputStr.Length; i++)
            {
                if (i != inputStr.Length - 1)
                {
                    string couple = inputStr.Substring(i, 2);
                    int cInt = int.Parse(couple);
                    if (cInt <= 26 && cInt > 0)
                    {
                        result++;
                    }
                }

                if (inputStr[i] != 0)
                {
                    result++;
                }
            }

            return result;
        }
        // Completed in 00:06:03

        /// An XOR linked list is a more memory efficient doubly linked list. Instead of each node holding next 
        /// and prev fields, it holds a field named both, which is an XOR of the next node and the previous node. 
        /// Implement an XOR linked list; it has an add(element) which adds the element to the end, and a 
        /// get(index) which returns the node at index.
        private static XorList<int> prob_11_07_2020()
        {
            var list = new XorList<int>();
            list.Add(5);
            list.Add(7);
            list.Add(4);
            list.Add(36);
            list.Add(12);
            return list;
        }
        public class XorList<T>
        {
            private int HeadIndex { get; set; }
            private MemoryMimic<T> _memory;

            public XorList()
            {
                _memory = new MemoryMimic<T>();
            }

            public void Add(T element)
            {
                if (HeadIndex == 0)
                {
                    HeadIndex = _memory.Add(new Node<T>(element));
                    return;
                }

                var currentPoint = 0;
                var nextPoint = HeadIndex;
                var prevPoint = 0;
                Node<T> currentNode;

                do
                {
                    currentNode = _memory[nextPoint];
                    prevPoint = currentPoint;
                    currentPoint = nextPoint;
                    nextPoint = currentNode.NextPrevValue ^ prevPoint;
                } while (nextPoint != 0);

                var newIndex = _memory.Add(new Node<T>(element));
                var newNode = _memory[newIndex];
                currentNode.NextPrevValue = prevPoint ^ newIndex;
                newNode.NextPrevValue = currentPoint;
            }

            public Node<T> Get(int index)
            {
                if (index < 0 || HeadIndex == 0) return null;
                var currentPoint = 0;
                var nextPoint = HeadIndex;
                var prevPoint = 0;
                Node<T> currentNode;
                var i = 0;

                do
                {
                    currentNode = _memory[nextPoint];
                    prevPoint = currentPoint;
                    currentPoint = nextPoint;
                    nextPoint = currentNode.NextPrevValue ^ prevPoint;
                    i++;
                } while (nextPoint != 0 && i <= index);

                if (nextPoint == 0 && (i - 1) != index) return null;

                return currentNode;
            }
        }
        public class Node<T>
        {
            public T Data { get; set; }
            public int NextPrevValue { get; set; }

            public Node(T data, int nextPrevValue = 0) { Data = data; NextPrevValue = nextPrevValue; }
            public override string ToString() { return Data.ToString(); }
        }
        public class MemoryMimic<T>
        {
            public List<Node<T>> _nodes;
            public List<int> _availIndexes;
            public Random rand;

            public MemoryMimic()
            {
                _nodes = new List<Node<T>>();
                _availIndexes = new List<int>();
                rand = new Random();
                AddSpace();
            }

            private void AddSpace()
            {
                for (var i = 0; i < 10; i++)
                {
                    _nodes.Add(null);
                    _availIndexes.Add(_nodes.Count);
                }
            }

            public int Add(Node<T> node)
            {
                var availIndex = rand.Next(_availIndexes.Count);
                var i = _availIndexes[availIndex];
                _nodes[i - 1] = node;
                _availIndexes.Remove(i);
                if (_availIndexes.Count == 0) AddSpace();
                return i;
            }

            public Node<T> this[int index]
            {
                get { return _nodes[index - 1]; }
                set { _nodes[index - 1] = value; }
            }
        }
        // Unable to solve, solution found at https://dotnetfiddle.net/uxBAzM and analyzed

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
