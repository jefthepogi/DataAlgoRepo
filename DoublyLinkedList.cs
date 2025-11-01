
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
            if (index >= Count || index < 0) // Check if chosen index is within the bounds
            {
                Console.WriteLine("\nInsert({0}): Index bound error.", index);
                return;
            }

            Node ptr = Head; // Initialize current pointer to Head.
            int idx = 0; // initialize initial index to zero.
            while (ptr != null) // Iterate if current pointer is not null.
            {   
                if (idx == index)  // If the idx matches the index value then do the appropriate swaps.
                {
                    Node new_node = new Node(value); // Create a new node.
                    // Swap the position of current node with the previous
                    Node prev_node = ptr.PreviousNode;
                    new_node.NextNode = ptr;
                    new_node.PreviousNode = prev_node;
                    ptr.PreviousNode = new_node;
                    prev_node.NextNode = new_node;
                    break;
                }
                ptr = ptr.NextNode; // Proceed to the next node
                idx++; // Increment index
            }

            Count++;
            
        }

        public int Get(int index)
        {
            // TODO: Complete the function
            Node ptr = Head; 
            int idx = 0;
            while (ptr != null) 
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
            Node ptr = Head; 
            int idx = 0;
            while (ptr != null) 
            {
                if (value == ptr.Value) // Check if parameter is equal to the current node value.
                {
                    Node prev_node = ptr.PreviousNode;
                    if (ptr.NextNode != null) // Check if there are dangling list
                    {
                        prev_node.NextNode = ptr.NextNode; // Connect that to the previous node.
                        return;
                    }

                    prev_node.NextNode = null; // If there are no dangling list, just assign it null.
                    
                }

                idx++; // Increment index.
                ptr = ptr.NextNode; // Proceed to the next node.
            }
        }

        public void RemoveAt(int index)
        {
            // TODO: Complete the function
            if (index < 0) // This is to allow negative indexing
            { 
                index = Count + index;
            }

            if (index >= Count || index < 0) 
            {
                Console.WriteLine("\nRemoveAt({0}): Index bound error.", index);
                return;
            }

            Node ptr = Head;
            int idx = 0;
            while (ptr != null)
            {
                if (idx == index)
                {
                    Node prev_node = ptr.PreviousNode;
                    if (prev_node == null) // If the previous node is null, then we must be at the head.
                    {
                        Head = ptr.NextNode; // Replace Head with its proceeding node.
                        Count--; // Decrement count
                    }
                    else if (ptr.NextNode != null) // If there are dangling list, connect it
                    {
                        prev_node.NextNode = ptr.NextNode;
                        Count--;
                    }
                    else {
                        prev_node.NextNode = null; // Else, just assign it null
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
            Node ptr = Head;
            int min = Head.Value; // Get first element as base value
            while (ptr != null)
            {
                if (ptr.Value < min) // Check if current node's value is less than current min
                {
                    min = ptr.Value; 
                }
                ptr = ptr.NextNode;
            }

            return min;
        }

        public int GetMax()
        {
            // TODO: Complete the function
            Node ptr = Head;
            int max = Head.Value;
            while (ptr != null)
            {
                if (ptr.Value > max) // Check if current node's value is larger than current max
                {
                    max = ptr.Value;
                }
                ptr = ptr.NextNode;
            }

            return max;
        }
    }

    public class Node
    {
        public Node NextNode = null;
        public Node PreviousNode = null; // Added new
                                         // that tracks the previous node.
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
            Console.WriteLine("\nAfter removing index 0, the number of items in the list " + myList.Count);
            PrintList(myList); // 2 3 4 5

            myList.RemoveAt(-1);
            Console.WriteLine("\nRemove index -1 from the last item, the number of items in the list " + myList.Count);
            PrintList(myList); // 2 3 4 (removing last item)

            myList.Insert(2, value: 10);
            Console.WriteLine("\nAfter inserting at index 2, the number of items in the list: " + myList.Count);
            PrintList(myList); // 2 3 10 4

            Console.WriteLine("\nSearch 10: " + myList.Search(10)); // 2
            Console.WriteLine("\nMin: " + myList.GetMin()); // 2
            Console.WriteLine("\nMax: " + myList.GetMax()); // 10

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