public class UnweightedDirectedGraph
{
    // Adjacency Lists
    private List<int> Vertices = new List<int> { };
    private List<List<int>> AdjacencyList = new List<List<int>> { };

    public void AddVertex(int V)
    {
        Vertices.Add(V);
        AdjacencyList.Add(new List<int> { });
    }

    public void AddEdge(int V, int W)
    {
        AdjacencyList[Vertices.IndexOf(V)].Add(Vertices.IndexOf(W));
    }

    public void PrintGraph()
    {
        for (int i = 0; i < Vertices.Count; i++)
        {
            var vertex = Vertices[i];
            Console.Write(vertex + " => ");
            foreach (var adj in AdjacencyList[i])
            {
                Console.Write(Vertices[adj] + ", ");
            }

            Console.WriteLine();
        }
    }

    public void BFS(int StartNode)
    {
        // TODO: To Complete
        Console.WriteLine("\nBreadth-First Search, Starting Node {0}:", StartNode);
        Queue<int> queue = new Queue<int>(new int[] { StartNode }); // Initialize a queue with the starting node.
        List<int> visited = new List<int>(); // Keeps track of the visited nodes.

        while (queue.Count > 0) // While queue is not empty
        {
            int node = queue.Dequeue(); // Dequeue the node
            if (!visited.Contains(node)) // Add it to the visited list
            {
                visited.Add(node);
            }

            int idx = Vertices.IndexOf(node); // Identify the index of that node.

            foreach (int adj in AdjacencyList[idx]) // For each adjacent nodes
            {
                int v = Vertices[adj];
                if (visited.Contains(v)) // Skip nodes already visited.
                {
                    continue;
                }
                queue.Enqueue(v); // If its a new node, enqueue it.
            }

        }

        foreach (var n in visited) // Print all the visited nodes
        {
            Console.Write(n + ", ");
        }

        Console.WriteLine("");
    }

    public void DFS(int StartNode)
    {
        // TODO: To Complete
        Console.WriteLine("\nDepth-First Search, Starting {0}:", StartNode);
        Stack<int> stack = new Stack<int>(new int[] { StartNode }); // Initialize a stack with the starting node.
        List<int> visited = new List<int>(); // Keeps track of the visited nodes.
        int already_visited = 0;

        while (stack.Count > 0) // If the stack isn't empty
        {
            int node = stack.Peek(); // Get the topmost node
            if (!visited.Contains(node))
            {
                visited.Add(node); // Add the node to the visited list
            }

            int idx = Vertices.IndexOf(node); // Get the index of the node

            //Console.WriteLine("\nCurrent Stack: ");
            //foreach (var n in stack)
            //{
            //    Console.Write(n + ", ");
            //}

            if (already_visited == AdjacencyList[idx].Count) // If the node connects to already visited nodes or none at all, then pop the stack
            {
                int pop = stack.Pop();
                //Console.WriteLine("Popped: " + pop);
                continue;
            }

            already_visited = 0;
            foreach (int adj in AdjacencyList[idx]) // For each adjacent nodes
            {
                int v = Vertices[adj];
                if (visited.Contains(v)) // Increment the already_visited integer, if the adjacent node was visited before
                {
                    already_visited++;
                    continue;
                }
                stack.Push(v); // If its a new node, push it to the stack.
            }
        }

        foreach (var n in visited) // Print all the visited nodes
        {
            Console.Write(n + ", ");
        }

        Console.WriteLine(); 

    }
}

public class UnweightedDigraphProgram
{
    public static void Main(string[] args)
    {
        var g = new UnweightedDirectedGraph();

        g.AddVertex(2);
        g.AddVertex(3);
        g.AddVertex(5);
        g.AddVertex(7);
        g.AddVertex(8);
        g.AddVertex(9);
        g.AddVertex(10);
        g.AddVertex(11);

        g.AddEdge(3, 8);
        g.AddEdge(3, 10);
        g.AddEdge(5, 11);
        g.AddEdge(7, 11);
        g.AddEdge(7, 8);
        g.AddEdge(8, 9);
        g.AddEdge(11, 2);
        g.AddEdge(11, 9);
        g.AddEdge(11, 10);
        

       
        g.PrintGraph();

        g.BFS(7);

    }
}
