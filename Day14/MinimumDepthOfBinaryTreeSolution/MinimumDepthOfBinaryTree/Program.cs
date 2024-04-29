using System.ComponentModel.Design.Serialization;

namespace MinimumDepthOfBinaryTree
{
    public class Node
    {
        public int Head;
        public Node Right;
        public Node Left;
        public Node(int value)
        {
            Head = value;
            Right = null;
            Left = null;
        }
    }

    public class Program
    {
        public async Task<int> MinimumDepthAsync(Node node)
        {
            
            
            if (node == null)
                return 0;
            if (node.Left==null && node.Right==null)
            {
                return 1;
            }
            int LeftDepth= await MinimumDepthAsync(node.Left);
            int RightDepth=await MinimumDepthAsync(node.Right);
            if (node.Left == null)
                return RightDepth + 1;

            if (node.Right == null)
                return LeftDepth + 1;

            return Math.Min(LeftDepth,RightDepth)+1;
        }
        public Node ArrayToTree(int?[] InputArray, int Head)
        {
            if (Head >= InputArray.Length || InputArray[Head] == null)
                return null;
            Node node = new Node(InputArray[Head].Value);
            node.Left=ArrayToTree(InputArray,2*Head+1);
            node.Right=ArrayToTree(InputArray,2*Head+2);
            return node;
        }
        public async void Calculate()
        {
            int?[] InputArray = { 2,null,3,null,4,null,5,null,6 };
            Program program = new Program();
            Node node = program.ArrayToTree(InputArray, 0);
            int MinimumDepth = await program.MinimumDepthAsync(node);
            Console.WriteLine($"Minimum depth is {MinimumDepth}");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Calculate();
        }
    }
}
