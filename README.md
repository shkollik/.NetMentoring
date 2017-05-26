# .NetMentoring
Task 1 Data Structures
  
  LinkedList:
1. Implement linked list with such function set: Length, Add, AddAt, Remove, RemoveAt, ElementAt.
2. Write down test cases in a document (txt, docx) to cover your linked list functionality.
3. Write unit test for all your test cases.
4. Implement Ienumerable to make your list work with foeach

  HashTable:
  
1. Implement your hashtable, you should not use .Net structures (you can use only: array or linked list).
2. Here is interface you must implement:
  interface IHashTable
  {
  bool Contains(object key);
  void Add(object key, object value);
  object this[object key] { get; set; } bool TryGet(object key, out object value)
  }
3. If setter tries to set null, such element must be removed from the dictionary.
4. Any .Net object can be used as a key or value.
5. If you try to add the object by a key which already exists in the hash table – throw an exception.

Task2 IDisposable
1. Code fix. Please download code from 
https://github.com/epm-dmentor/2015-mentoring-program/tree/master/practice/tasks/IDisposable/IDisposableImplementation
and review it, if something is wrong correct it.
2. Fix code. Unmanaged code usage. FileWriter 
https://github.com/epm-dmentor/2015-mentoring-program/tree/master/practice/tasks/IDisposable/FileWriter
