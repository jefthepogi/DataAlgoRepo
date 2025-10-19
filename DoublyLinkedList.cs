
namespace Manongas_DataAlgo {
    public class DoublyLinkedList
    {
        public int Count { get; private set; }
        private Node Head = null;
        private Node Tail = null;

        public void Add(int value)
        {
            // TODO: Complete the function
        }

        public void Insert(int index, int value)
        {
            // TODO: Complete the function
        }

        public int Get(int index)
        {
            // TODO: Complete the function
            return -1;
        }

        public void Remove(int value)
        {
            // TODO: Complete the function
        }

        public void RemoveAt(int index)
        {
            // TODO: Complete the function
        }

        public void Search(int value)
        {
            // TODO: Complete the function
        }

        public int GetMin()
        {
            // TODO: Complete the function
            return -1;
        }

        public int GetMax()
        {
            // TODO: Complete the function
            return -1;
        }
    }

    public class Node
    {
        public Node NextNode = null;
        public int Value;

        public Node(int value)
        {
            Value = value;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var myList = new DoublyLinkedList();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            Console.WriteLine("The number of items in the list: " + myList.Count);
            PrintList(myList); // 1 2 3 4 5

            myList.RemoveAt(0);
            Console.WriteLine("\nAfter removing index 4, the number of items in the list " + myList.Count);
            PrintList(myList); // 2 3 4 5

            myList.RemoveAt(-1);
            Console.WriteLine("\nRemove index 1 from the last item, the number of items in the list " + myList.Count);
            PrintList(myList); // 2 3 4 (removing last item)

            myList.Insert(2, value: 10);
            Console.WriteLine("\nAfter inserting at index 2, the number of items in the list: " + myList.Count);
            PrintList(myList); // 2 3 10 4

            Console.WriteLine("\nSearch 10: " + myList.Search(10)); // 2
            Console.WriteLine("\nMin: " + myList.GetMin()); // 2
            Console.WriteLine("\nMax: " + myList.GetMin()); // 10

            Console.ReadKey();
        }

        static void PrintList(DoublyLinkedList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list.Get(i) + " ");
            }

            Console.WriteLine();
        }
    }
}