using System;

namespace LibraryManagementSystem.DataStructures
{
    public class CustomHashTable<K, V>
    {
        private class HashNode
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public HashNode Next { get; set; }
        }

        private HashNode[] buckets;

        public CustomHashTable(int size = 10)
        {
            buckets = new HashNode[size];
        }

        private int GetBucketIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % buckets.Length);
        }

        public void Add(K key, V value)
        {
            int index = GetBucketIndex(key);
            var newNode = new HashNode { Key = key, Value = value, Next = buckets[index] };
            buckets[index] = newNode;
        }

        public V Get(K key)
        {
            int index = GetBucketIndex(key);
            var current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                    return current.Value;
                current = current.Next;
            }

            throw new KeyNotFoundException("Key not found.");
        }
    }
}

