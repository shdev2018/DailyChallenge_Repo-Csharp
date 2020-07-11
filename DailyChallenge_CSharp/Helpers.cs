using System;
using System.Collections.Generic;
using System.Text;

namespace DailyChallenge_Csharp
{
    class Helpers
    {
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
    }
}
