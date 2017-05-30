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

Task 2 IDisposable
1. Code fix. Please download code from 
https://github.com/epm-dmentor/2015-mentoring-program/tree/master/practice/tasks/IDisposable/IDisposableImplementation
and review it, if something is wrong correct it.
2. Fix code. Unmanaged code usage. FileWriter 
https://github.com/epm-dmentor/2015-mentoring-program/tree/master/practice/tasks/IDisposable/FileWriter

Task project is forked and with my changes located here: 2.1 -> https://github.com/shkollik/2015-mentoring-program/tree/master/practice/tasks/IDisposable/IDisposableImplementation
														 2.2 -> https://github.com/shkollik/2015-mentoring-program/tree/master/practice/tasks/IDisposable/FileWriter
To compare changes of code fix go : https://github.com/epm-dmentor/2015-mentoring-program/compare/master...shkollik:master

Task 3 Garbage Collector
1. Please download code from https://github.com/epm-dmentor/2015-mentoring-program/tree/master/practice/tasks/IDisposable/ZooInDanger. 
Zoo application has an issue at some moment garbadge collection stops working properly. Please find out the reason, resolve it and explain.

Task project is forked and with my changes located here: https://github.com/shkollik/2015-mentoring-program/tree/master/practice/tasks/IDisposable/ZooInDanger
To compare changes of code fix go : https://github.com/shkollik/2015-mentoring-program/blob/6acb21eff8fcf9f9aaeaf0602695874935be148a/practice/tasks/IDisposable/ZooInDanger/ZooInDanger/Animals/Cat.cs
									Commented the check in finalizer that leads to garbage collector issues

