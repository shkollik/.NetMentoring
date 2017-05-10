using System;
using System.Collections.Generic;
using System.Linq;


namespace Hashtable
{
    class HashTable : IHashTable
    {
        LinkedList<Node>[] buckets;
        private int size = 12; // min number of buckets

        public HashTable()
        {
            buckets = new LinkedList<Node>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new LinkedList<Node>();
            }
        }
        public object this[object key]
        {
            get
            {
                //if (Contains(key))
                //{
                //    throw new ArgumentException();
                //}
                //return buckets[DefineBucketWhereToStore(key)].Where(x => x.key.Equals(key)).First().value;
                return Get(key);
            }

            set
            {
                //buckets[DefineBucketWhereToStore(key)].AddLast(new Node(key, value));
                Add(key, value);
            }
        }

        public bool Contains(Object key)
        {
            if (key == null)
            {
                throw new ArgumentException();
            }

            int bucketNumber = DefineBucketWhereToStore(key);
            LinkedList<Node> listOfKeyValuePairsInsideBucket = buckets[bucketNumber];
            //for (int i = 0; i < listOfKeyValuePairsInsideBucket.Count; i++)
            //{
            //    if (listOfKeyValuePairsInsideBucket.ElementAt(i).key.Equals(key))
            //    {
            //        return true;
            //    }
            //}

            //return false;
            
            ListContainsKey(listOfKeyValuePairsInsideBucket, key);
            return false;
        }
        

        private bool ListContainsKey(LinkedList<Node> listOfKeyValuePairsInsideBucket, Object key)
        {
            for (int i = 0; i < listOfKeyValuePairsInsideBucket.Count; i++)
            {
                if (listOfKeyValuePairsInsideBucket.ElementAt(i).key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(Object key, Object value)
        {
            int bucketNumber = DefineBucketWhereToStore(key);
            LinkedList<Node> listOfKeyValuePairsInsideBucket = GetKeyValuePairsOfBucket(bucketNumber);
            //if (listOfKeyValuePairsInsideBucket.Contains(key))
            //{
            //    throw new ArgumentException();
            //}
            if(ListContainsKey(listOfKeyValuePairsInsideBucket, key))
            {
                throw new ArgumentException();
            }

            if(value != null)
            {
                listOfKeyValuePairsInsideBucket.AddLast(new Node(key, value));
            }
        }

        private int DefineBucketWhereToStore(Object key)
        {
            int bucketNumber = key.GetHashCode() % (size -1);
            return Math.Abs(bucketNumber);
        }

        private LinkedList<Node> GetKeyValuePairsOfBucket(int bucketNumber)
        {
            LinkedList<Node> listOfKeyValuePairsInsideBucket = buckets[bucketNumber];
            if(listOfKeyValuePairsInsideBucket == null)
            {
                listOfKeyValuePairsInsideBucket = new LinkedList<Node>();
                buckets[bucketNumber] = listOfKeyValuePairsInsideBucket;
            }

            return buckets[bucketNumber];
        }

        public bool TryGet(Object key, out Object value)
        {
            int bucketNumber = DefineBucketWhereToStore(key);
            LinkedList<Node> listOfKeyValuePairsInsideBucket = GetKeyValuePairsOfBucket(bucketNumber);

            //if (!listOfKeyValuePairsInsideBucket.Contains(key))
            //{
            //    throw new ArgumentException();
            //}
            if (!ListContainsKey(listOfKeyValuePairsInsideBucket, key))
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < listOfKeyValuePairsInsideBucket.Count; i++)
            {
                if (listOfKeyValuePairsInsideBucket.ElementAt(i).key.Equals(key))
                {
                    value = listOfKeyValuePairsInsideBucket.ElementAt(i).value;
                    return true;
                }
            }

            value = default(Object);
            return false;
        }

        private Object Get(Object key)
        {
            Object value = TryGet(key, out value); ;
            return value;
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
