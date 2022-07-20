using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a binary tree, invert the tree, and return its root.
     *                  4               4
     *                 / \             / \
     *                2   7           7   2
     *               /\   /\         /\   /\
     *              1  3 6  9       9  6 3  1
     */
    public class InvertBinaryTree : TheoryData<TreeNode, TreeNode>
    {
        public InvertBinaryTree()
        {
            Add(new(4, new(2, new(1), new(3)), new(7, new(6), new(9))), new(4, new(7, new(9), new(6)), new(2, new(3), new(1))));
        }

        [Theory]
        [ClassData(typeof(InvertBinaryTree))]
        public void Invert_Given_BinaryTree(TreeNode input, TreeNode expectedResult)
        {
            var result = InvertTree(input);
            Assert.True(expectedResult.AreEqual(result));
        }

        public TreeNode? InvertTree(TreeNode? root)
        {
            if (root == null)
            {
                return null;
            }

            var temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }
    }
}
