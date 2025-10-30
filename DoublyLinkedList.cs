
namespace Manongas_DataAlgo {
    public class DoublyLinkedList
    {
        public int Count { get; private set; }
        private Node Head = null;
        private Node Tail = null;

        public void Add(int value)
        {
            // TODO: Complete the function
            Count++; // Increment count var.
            Node new_node = new Node(value); // Initialize a new node

            if (Head == null) {
                Head = new_node;
                Tail = new_node;
                Head.PreviousNode = null;
                return;
            }
            Tail.NextNode = new_node; // Point next node of the current tail to the new node.
            new_node.PreviousNode = Tail; // Point previous node of the new node to the current tail.
            Tail = new_node; // Replace tail with the new node.
        }

        public void Insert(int index, int value)
        {
            // TODO: Complete the function
            Node ptr = Head;
            int idx = 0;
            while (ptr == null) 
            {   
                if (idx == index - 1)
                {
                    Node next_node = ptr.NextNode;
                    Node new_node = new Node(value);
                    new_node.PreviousNode = ptr;
                    new_node.Value = value;
                    next_node.PreviousNode = new_node;
                    ptr.NextNode = new_node;
                }
                ptr = ptr.NextNode;
                idx++;
            }
            
        }

        public int Get(int index)
        {
            // TODO: Complete the function
            Node ptr = Head; // Initialize current pointer to Head.
            int idx = 0; // initialize initial index to zero.
            while (ptr != null) // Iterate if current pointer is not null.
            {
                if (idx == index) // If the idx matches the index value then return current node's value.
                {
                    return ptr.Value;
                }
                idx++;
                ptr = ptr.NextNode; // Proceed to next node.
            }
            return -1;
        }

        public void Remove(int value)
        {
            // TODO: Complete the function
        }

        public void RemoveAt(int index)
        {
            // TODO: Complete the function
            Node ptr = Head;
            int idx = 0;
            while (ptr != null)
            {
                Console.WriteLine("wdw");
                if (idx == index)
                {
                    Node prev_node = ptr.PreviousNode;
                    if (prev_node == null) 
                    {
                        Head = ptr.NextNode;
                        Count--;
                    }
                    else if (ptr.NextNode != null)
                    {
                        prev_node.NextNode = ptr.NextNode;
                        Count--;
                    }
                    else {
                        prev_node.NextNode = null;
                        Count--;
                    }
                    break;
                }

                ptr = ptr.NextNode;
                idx++;
            }
        }

        public int Search(int value)
        {
            // TODO: Complete the function
            Node ptr = Head; // Initialize current pointer to Head.
            int idx = 0; // initialize initial index to zero.
            while (ptr != null) // Iterate if current pointer is not null
            {
                if (value == ptr.Value) // Check if parameter is equal to the current node value.
                {
                    return idx; // Return index.
                }

                idx++; // Increment index.
                ptr = ptr.NextNode; // Proceed to the next node.
            }
            return -1;
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
        public Node PreviousNode = null; // Added new field that tracks the previous node.
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