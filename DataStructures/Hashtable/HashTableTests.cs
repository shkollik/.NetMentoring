using NUnit.Framework;
using System;

namespace Hashtable
{
    [TestFixture]
    class HashTableTests
    {
        [Test]
        public void ContainsKeyThatExists()
        {
            HashTable hashTable = new HashTable();
            int key = 1;
            hashTable.Add(key, 100);

            Assert.IsTrue(hashTable.Contains(key));
        }

        [Test]
        public void ContainsKeyThatDoesnotExist()
        {
            HashTable hashTable = new HashTable();
            int existedKey = 1;
            int nonExistedKey = 2;
            hashTable.Add(existedKey, 100);

            Assert.IsFalse(hashTable.Contains(nonExistedKey));
        }

        [Test]
        public void ContainsKeyNull()
        {
            HashTable hashTable = new HashTable();
            Assert.Throws(typeof(ArgumentException), () => hashTable.Contains(null));
        }

        [Test]
        public void AddIfKeyDoesntExistYet()
        {
            HashTable hashTable = new HashTable();
            int key = 30;
            int value = 300;
            hashTable.Add(key, value);

            Assert.AreEqual(value, hashTable[key]);
        }

        [Test]
        public void AddIfKeyAlreadyExists()
        {
            HashTable hashTable = new HashTable();
            int key = 2;
            hashTable.Add(key, 100);

            Assert.Throws(typeof(ArgumentException), () => hashTable.Add(key, 200));
        }

        [Test]
        public void AddIfKeyIsNull()
        {
            HashTable hashTable = new HashTable();
            Assert.Throws(typeof(ArgumentException), () => hashTable.Add(null, 200));
        }

        [Test]
        public void AddIfValueIsNull()
        {
            HashTable hashTable = new HashTable();
            hashTable.Add(1, null); // if value -null, than item will not be added to hashtable

            Assert.IsTrue(hashTable.GetSize().Equals(0));
        }

        [Test]
        public void AddifLoadFactorExceeds()
        {
            int capacity = 2;
            double loadFactor = 0.75;
            HashTable hashTable = new HashTable(capacity, loadFactor);
            hashTable.Add(1, 300);
            hashTable.Add(2, 900);

            int elementAfteRehashing = 1000;
            hashTable.Add(3, elementAfteRehashing);

            Assert.AreEqual(elementAfteRehashing, hashTable[3]);
        }

        [Test]
        public void TryGetIfKeyAlreadyExists_ReturnsTrue()
        {
            HashTable hashTable = new HashTable();
            int key = 5;
            hashTable.Add(5, 2000);

            Object value;
            Assert.IsTrue(hashTable.TryGet(key, out value).Equals(true));
        }

        [Test]
        public void TryGetIfKeyAlreadyExists_SetsValue()
        {
            HashTable hashTable = new HashTable();
            int key = 5;
            int inputValue = 2000;
            hashTable.Add(5, inputValue);

            Object outputvalue;
            hashTable.TryGet(key, out outputvalue);
            Assert.AreEqual(inputValue, outputvalue);
        }

        [Test]
        public void TryGetIfKeyDoesntExistYet()
        {
            HashTable hashTable = new HashTable();
            int unExistedKey = 10;

            object value;
            Assert.That(() => hashTable.TryGet(unExistedKey, out value), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TryGetIfKeyIsNull()
        {
            HashTable hashTable = new HashTable();

            object value;
            Assert.Throws(typeof(ArgumentException), () => hashTable.TryGet(null, out value));
        }
    }
}
