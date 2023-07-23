namespace ADV_6
{
    internal class Program
    {
        /*
        Solve DS-19 in O(n) time complexity and O(1) space complexity.
        DS-19: Write a function that validates that a Binary Search Tree or sub-tree is a valid BST (that is, follows the rules of a BST):
        No modifications to the tree are allowed. The tree can be arbitrarily large; however the depth is guaranteed to be less than 2^10

        Rules of BST:
        All of the nodes with values less than the root are on the left side of the tree, and all of the nodes with values greater than the root are on the right.

        Followup:

        BST 2 nodes have been swapped so that they both violate the BST property
        find them
        same constraints
        */

        static void Main(string[] args)
        {
            Node root = new Node(10);
            root.Left = new Node(5);
            root.Left.Left = new Node(3);

            root.Right = new Node(15);
            root.Right.Left = new Node(11);
            root.Right.Left.Left = new Node(4);
            root.Right.Left.Right = new Node(14);
            root.Right.Right = new Node(20);

            var yeet = IsValidBST(root, int.MinValue);
            ;
        }

        public static bool IsValidBST(Node tree, int prevValue)
        {
            if (tree == null || tree.Left == null) return true;//assumes tree is full

            if (tree.Left.Value < prevValue)
            {
                return false;
            }
            
            else if (prevValue < tree.Value) //need to do left side
            {
                return IsValidBST(tree.Left, prevValue) && IsValidBST(tree.Right, tree.Value);
            }

            else if (prevValue < tree.Right.Value) //done with left, need to do right
            {
                return IsValidBST(tree.Right, tree.Value);
            }

            else
            {
                return true;
            }
        }

        /* Attempt 1
        bool right;
        bool left;
        if (tree.Left != null)//left side check
        {
            if (tree.Left.Value < tree.Value)//the basic check
            {
                if (tree.Value > parentValue)//tree is right child
                {
                    if (tree.Left.Value > parentValue)
                    {
                        left = true;
                    }
                    else left = false;
                }
                else left = true;
            }
            else left = false;

            left &= IsValidBST(tree.Left, tree.Value);
        }
        else left = true;



        if (tree.Right != null)//right side check
        {
            if (tree.Right.Value > tree.Value)//the basic check
            {
                if (tree.Value < parentValue)//tree is left child
                {
                    if (tree.Right.Value < parentValue)
                    {
                        right = true;
                    }
                    else right = false;
                }
                else right = true;
            }
            else right = false;

            right &= IsValidBST(tree.Right, tree.Value);
        }
        else right = true;



        return left && right;
        */
    }
}