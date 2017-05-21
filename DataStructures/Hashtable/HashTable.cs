using System;
using System.Collections.Generic;
using System.Linq;


namespace Hashtable
{
    class HashTable : IHashTable
    {
        LinkedList<Node>[] buckets;
        private int capacity = 12;
        private double loadFactor = 0.75;
        private int hashTableSize;

        public HashTable()
        {
            InitializeHashTable();
        }

        public HashTable(int capacity)
        {
            this.capacity = capacity;
            InitializeHashTable();
        }

        public HashTable(int capacity, double loadFactor)
        {
            this.capacity = capacity;
            this.loadFactor = loadFactor;
            InitializeHashTable();
        }

        private void InitializeHashTable()
        {
            buckets = new LinkedList<Node>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                buckets[i] = new LinkedList<Node>();
            }
        }

        public object this[object key]
        {
            get
            {
                return Get(key);
            }

            set
            {
                Add(key, value);
            }
        }

        public bool Contains(Object key)
        {
            if (key == null)
            {
                throw new ArgumentException("Key can not be null");
            }

            LinkedList<Node> listOfNodesInsideBucket = GetListOfNodesInsideBucket(key);

            return ListContainsKey(listOfNodesInsideBucket, key);
        }

        private LinkedList<Node> GetListOfNodesInsideBucket(object key)
        {
            int bucketNumber = DefineBucketWhereToStore(key);
            LinkedList<Node> listOfNodesInsideBucket = buckets[bucketNumber];
            return listOfNodesInsideBucket;
        }

        private bool ListContainsKey(LinkedList<Node> listOfNodesInsideBucket, Object key)
        {
            for (int i = 0; i < listOfNodesInsideBucket.Count; i++)
            {
                if (listOfNodesInsideBucket.ElementAt(i).key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(Object key, Object value)
        {
            if (key == null)
            {
                throw new ArgumentException("Key can not be null");
            }
            
            if (GetLoadFactor() > loadFactor)
            {
                Rehash();
            }

            LinkedList<Node> listOfNodesInsideBucket = GetListOfNodesInsideBucket(key);
            if (ListContainsKey(listOfNodesInsideBucket, key))
            {
                throw new ArgumentException();
            }
            
            if (value != null)
            {
                listOfNodesInsideBucket.AddLast(new Node(key, value));
                hashTableSize++;
            }
        }

        public bool TryGet(Object key, out Object value)
        {
            if(Get(key) != null)
            {
                value = Get(key);
                return true;
            }
            else
            {
                value = default(Object);
                return false;
            }
        }

        private Object Get(Object key)
        {
            if (key == null)
            {
                throw new ArgumentException("Key can not be null");
            }

            LinkedList<Node> listOfNodesInsideBucket = GetListOfNodesInsideBucket(key);
            if (!ListContainsKey(listOfNodesInsideBucket, key))
            {
                throw new ArgumentException();
            }

            Object value = null;
            for (int i = 0; i < listOfNodesInsideBucket.Count; i++)
            {
                if (listOfNodesInsideBucket.ElementAt(i).key.Equals(key))
                {
                    value = listOfNodesInsideBucket.ElementAt(i).value;
                }
            }
            return value;
        }

        private int DefineBucketWhereToStore(Object key)
        {
            int bucketNumber = key.GetHashCode() % (buckets.Length);
            return Math.Abs(bucketNumber);
        }

        private int GetLoadFactor()
        {
            return hashTableSize / capacity;
        }

        private void Rehash()
        {
            LinkedList<Node>[] tempBuckets = buckets;
            capacity = capacity * 2;
            InitializeHashTable();

            for (int arrayCounter = 0; arrayCounter < tempBuckets.Length; arrayCounter++)
            {
                for (int nodeCounter = 0; nodeCounter < tempBuckets[arrayCounter].Count; nodeCounter++)
                {
                    int bucketNumber = DefineBucketWhereToStore(tempBuckets[arrayCounter].ElementAt(nodeCounter).key);
                    buckets[bucketNumber].AddLast(new Node(tempBuckets[arrayCounter].ElementAt(nodeCounter).key, tempBuckets[arrayCounter].ElementAt(nodeCounter).value));
                }
            }
        }

        public int GetSize()
        {
            return hashTableSize;
        }

        private class Node
        {
            public Object key;
            public Object value;

            public Node(Object key, Object value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
