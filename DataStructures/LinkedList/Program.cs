namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList<int> list = new LinkedList<int>();
            //list.AddToTheBeginning(1);
            //list.AddToTheBeginning(1);
            //list.AddToTheEnd(2);
            //list.AddToTheEnd(3);

            //list.AddAt(1, 10);
            //Console.WriteLine(list.GetLength());

            //foreach (int element in list)
            //{
            //    System.Console.WriteLine(element);
            //}

            //System.Console.WriteLine(list.ElementAt(2));

            //list.RemoveFromTheBeginning();
            //System.Console.WriteLine(list.GetLength());

            //list.RemoveAt(1);
            //Console.WriteLine(list.GetLength());


            //LinkedList<int> list = new LinkedList<int> { 1, 2, 3, 4, 5 };
            //list.RemoveAt(4);
            //foreach (int element in list)
            //{
            //    System.Console.WriteLine(element);
            //}

            LinkedList<int> list = new LinkedList<int>();
            list.RemoveFromTheBeginning();
            System.Console.WriteLine(list.GetLength());
            //d





        }
    }
}
