using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class DFS
    {

      public void test()
        {

            int tstCase = 3;// int.Parse(Console.ReadLine());

            for (int i = 0; i < tstCase; i++)
            {
                int N = int.Parse(Console.ReadLine());
                int l = int.Parse(Console.ReadLine());
                BicolorTest graph = new BicolorTest(N + 1);
                for (int j = 0; j < l; j++)
                {
                    string[] strArr = Console.ReadLine().Split();
                    graph.AddEdge(int.Parse(strArr[0]) + 1, int.Parse(strArr[1]) + 1, false);
                }

                graph.Solution();

            }
        
       
}


    }


    class BicolorTest
    {

        LinkedList<int>[] linkedListArray;



        public BicolorTest(int v)
        {
            linkedListArray = new LinkedList<int>[v];


        }

        public void AddEdge(int u, int v, bool blnBiDir = true)
        {
            if (linkedListArray[u] == null)
            {
                linkedListArray[u] = new LinkedList<int>();
                linkedListArray[u].AddFirst(v);
            }
            else
            {
                var last = linkedListArray[u].Last;
                linkedListArray[u].AddAfter(last, v);
            }


            if (blnBiDir)
            {
                if (linkedListArray[v] == null)
                {
                    linkedListArray[v] = new LinkedList<int>();
                    linkedListArray[v].AddFirst(u);
                }
                else
                {
                    var last = linkedListArray[v].Last;
                    linkedListArray[v].AddAfter(last, u);
                }
            }




        }

        internal bool DFS(int src, int[] visited, int[] color)
        {
            visited[src] = 1;
            bool isBiColor = true;


            //Console.Write(src + "->");
            if (linkedListArray[src] != null)
            {
                foreach (var item in linkedListArray[src])
                {


                    if (visited[item] == -1)
                    {
                        color[item] = (color[src] + 1) % 2;
                        bool returnR = DFS(item, visited, color);
                        // Console.WriteLine("SF=" + src + "  DF=" + item + "  =" + isBiColor);

                        isBiColor = (returnR & isBiColor);
                    }
                    else if (color[item] == color[src])
                    {

                        isBiColor = false;
                        //  Console.WriteLine("S=" + src + "  D=" + item + "  =" + isBiColor);
                        return isBiColor;

                    }

                }
            }

            return isBiColor;


        }
        internal void Solution()
        {

            int[] visited = new int[linkedListArray.Length + 1];
            int[] color = new int[linkedListArray.Length + 1];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = -1;
                color[i] = -1;



            }
            color[1] = 1;
            bool bicolor = DFS(1, visited, color);
            if (bicolor)
            {

                Console.WriteLine("BICOLORABLE.");

            }
            else
            {
                Console.WriteLine("NOT BICOLORABLE.");
            }

        }

    }
}



//static int[] reverseInPlace(int[] input) {
//    int[] ArrlRev = new int[input.Length];
//    int fItem = input[0];
//    for (int i = 0; i < input.Length - 1; i++)
//    {



//        input[i] = input[i + 1];
//        if (i == input.Length - 2)
//            input[input.Length - 1] = fItem;






//    }
//    return input;
//}


//Node head;

//public class Node
//{
//    public int Data;
//    public Node nextNode;
//    public Node(int d) {

//        Data = d;
//    }
//}



//public void deleteNodes(int val) { 
//    if (head == null || head.nextNode == null) {

//        head = null;
//    }

//    Node fast = head;
//    Node slow = head;
//    Node prev = null;

//    while (fast != null && fast.nextNode!=null) {
//        prev = slow;
//        slow = slow.nextNode;
//        fast = fast.nextNode.nextNode;

//    }
//    prev.nextNode = null;
//}

//public void viewContent()
//{

//    Node Current = head;
//    while (Current != null)
//    {
//        Console.Write(Current.Data + "->");
//        Current = Current.nextNode;

//    }

//}
//public void deleteKthNode(int k)
//{
//   if(head==null || k == 0)
//    {

//        return;
//    }

//    Node first = head;
//    Node second = head;
//    //[3, 4 ,5 ,6] k=2
//    for (int i = 0; i<k; i++) {

//        second = second.nextNode;
//        if (second.nextNode == null)
//        {
//            // K >= Length of List
//            if (i == k - 1)
//            {
//                head = head.nextNode;
//            }
//            return;
//        }
//    }
//    Console.WriteLine("get Data head=" + head.Data);
//    Console.WriteLine("get Data second=" + second.Data);
//   // Console.WriteLine("second.nextNode =" + second.nextNode.Data);
//    while (second.nextNode != null) {
//        first = first.nextNode;
//        second = second.nextNode;

//    }

//    first.nextNode = first.nextNode.nextNode;


//   }
//public void deleteKthNodeFromEnd(int k)
//{

//    if (head == null || k == 0)
//    {
//        return;
//    }

//    // [a, b, c, d]
//    // k = 2
//    Node first = head;
//    Node second = head;

//    for (int i = 0; i < k; i++)
//    {
//        second = second.nextNode;
//        if (second.nextNode == null)
//        {
//            // K >= Length of List
//            if (i == k - 1)
//            {
//                head = head.nextNode;
//            }
//            return;  
//        }
//    }

//    // second = c

//    while (second.nextNode != null)
//    {
//        first = first.nextNode;
//        second = second.nextNode;
//    }              

//    // first = b
//    // second = d

//    // [a, b, c, d]
//    // k = 2

//    first.nextNode = first.nextNode.nextNode;
//}

//static Boolean hasBooleanMassingParentheash(string s) {

//    Stack<char> stack = new Stack<char>();
//    for (int i = 0; i < s.Length; i++)
//    {

//        char current = s[i];
//        if (current == '(') {
//            stack.Push(current);
//            continue;
//        }
//        if (current == ')')
//        {
//            if (stack.Count > 0)
//            {
//                stack.Pop();
//            }
//            else {
//                return false;
//            }

//            continue;
//        }


//    }

//    return stack.Count==0;

//}

//static Dictionary<char, int> frequentItemAddToDisctionary(string arr) {
//    Dictionary<char, int> dictionaryData = new Dictionary<char, int>();

//    char[] arr1 = arr.ToCharArray();
//    Array.ForEach(arr1, Console.WriteLine);
//    for (int i = 0; i < arr1.Length; i++) {

//        if (dictionaryData.ContainsKey(arr1[i]))
//        {

//            dictionaryData[arr1[i]]++;
//        }
//        else {

//            dictionaryData[arr1[i]] = 1;
//        }


//    }



//    return dictionaryData;



//}

//class Node {

//    public Node Left { set; get; }
//    public Node Right { set; get; }
//    public int Data { set; get; }

//}

//class BinarySearchTree {

//    public static Node Insert(Node root, int value) {

//        if (root == null)
//        {

//            root = new Node();
//            root.Data = value;
//            return root;

//        }
//        else {

//            if (value < root.Data)
//            {
//                root.Left = Insert(root.Left, value);

//            }
//            else if (value > root.Data) {

//                root.Right = Insert(root.Right, value);
//            }
//        }

//        return root;

//    }

//   public static void preOrderTraversal(Node root) {

//        if (root == null) {

//            return;
//         }
//        Console.Write(root.Data+"  ");
//        preOrderTraversal(root.Left);
//        preOrderTraversal(root.Right);
//      }

//    public static void inOrderTraversal(Node root)
//    {

//        if (root == null)
//        {

//            return;
//        }

//        inOrderTraversal(root.Left);
//        Console.Write(root.Data + "  ");
//        inOrderTraversal(root.Right);
//    }

//    public static void postOrderTraversal(Node root)
//    {

//        if (root == null)
//        {

//            return;
//        }

//        postOrderTraversal(root.Left);
//        postOrderTraversal(root.Right);
//        Console.Write(root.Data + "  ");
//    }

//}




//class Bicolor {

//    private int _v;
//    private bool _direct;
//    LinkedList<int>[] _adj;

//    public Bicolor(int v, bool direct)
//    {
//        _adj = new LinkedList<int>[v];

//        for (int i = 0; i < _adj.Length; i++)
//        {
//            _adj[i] = new LinkedList<int>();
//        }
//         _v = v;
//        _direct = direct;

//      }





//}

//public bool CanFinish(int numCourses, int[][] prerequisites)
//{
//    int[] gcolor = new int[numCourses];
//    Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();

//    for (int i = 0; i < numCourses; i++)
//    {
//        adjList[i] = new List<int>();
//    }

//    foreach (int[] edge in prerequisites)
//    {
//        adjList[edge[0]].Add(edge[1]);
//    }

//    //0-> not processed, 1-> under process, 2-> processing completed
//    for (int i = 0; i < numCourses; i++)
//    {
//        if (gcolor[i] == 0)
//        {
//            bool res = dfs(i, gcolor, adjList);
//            if (!res) return false;
//        }
//    }
//    return true;
//}
//private bool dfs(int i, int[] gcolor, Dictionary<int, List<int>> adjList)
//{
//    if (gcolor[i] == 1) return false;

//    if (gcolor[i] == 2) return true;

//    gcolor[i] = 1;
//    foreach (int neighbour in adjList[i])
//    {
//        bool res = dfs(neighbour, gcolor, adjList);
//        if (!res) return false;
//    }

//    gcolor[i] = 2;
//    return true;
//}
//public class Solution
//{
//    public bool IsBipartite(int[][] graph)
//    {
//        var n = graph.Length;

//        // 1 = red, -1 = blue, 0 = not colored yet.
//        var colors = new int[n];

//        var q = new Queue<int>();
//        for (int i = 0; i < n; i++)
//        {
//            if (colors[i] != 0) continue;

//            colors[i] = 1;
//            q.Enqueue(i);

//            while (q.Count > 0)
//            {
//                int node = q.Dequeue();
//                foreach (var neigh in graph[node])
//                {
//                    if (colors[neigh] == 0)
//                    {
//                        // color neighbour with opposite color
//                        colors[neigh] = -colors[node];
//                        q.Enqueue(neigh);
//                    }
//                    else if (colors[neigh] == colors[node])
//                        return false; // same color cannot be bipartite
//                }
//            }
//        }
//        return true;
//    }
//}
public class Graph
{
    LinkedList<int>[] linkedListArray;

    public Graph(int v)
    {
        linkedListArray = new LinkedList<int>[v];

        Console.Write(linkedListArray.Length);
    }

    /// 

    /// The method takes two nodes for which to add edge.
    /// 

    /// 
    /// 
    /// 
    public void AddEdge(int u, int v, bool blnBiDir = true)
    {
        if (linkedListArray[u] == null)
        {
            linkedListArray[u] = new LinkedList<int>();
            linkedListArray[u].AddFirst(v);
        }
        else
        {
            var last = linkedListArray[u].Last;
            linkedListArray[u].AddAfter(last, v);
        }


        if (blnBiDir)
        {
            if (linkedListArray[v] == null)
            {
                linkedListArray[v] = new LinkedList<int>();
                linkedListArray[v].AddFirst(u);
            }
            else
            {
                var last = linkedListArray[v].Last;
                linkedListArray[v].AddAfter(last, u);
            }
        }
    }

    internal void DFSHelper(int src, bool[] visited)
    {
        visited[src] = true;
        Console.Write(src + "->");
        if (linkedListArray[src] != null)
        {
            foreach (var item in linkedListArray[src])
            {
                if (!visited[item] == true)
                {
                    DFSHelper(item, visited);
                }
            }
        }
    }
    internal void DFS()
    {
        Console.WriteLine("DFS");
        bool[] visited = new bool[linkedListArray.Length + 1];
        DFSHelper(1, visited);

    }
}
