namespace ADV_204
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(Node Next, int Value)
        {
            next = Next;
            value = Value;
        }
    }

    internal class Program
    {
        //Linked list consisting of value and next only
        //get nth from the end element of linked list
        //guaranteed at least n elements
        static void Main(string[] args)
        {
            Node node = new Node(new Node(new Node(new Node(new Node(new Node(null, 5), 4), 3), 2), 1), 0);

            var yeet = GetNthFromEnd(node, 2);
            ;
        }

        public static Node GetNthFromEnd(Node node, int n)
        {
            Node nBehind = node;
            while (node.next != null)
            {
                if (n > 0)
                {
                    n--;
                }
                else
                {
                    nBehind = nBehind.next;
                }
                node = node.next;
            }
            return nBehind;
        }
    }
}