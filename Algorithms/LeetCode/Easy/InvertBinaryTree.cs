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
     *              1  3 6  9       6  9 3  1
     */
    public class InvertBinaryTree : TheoryData<TreeNode, TreeNode>
    {
        public InvertBinaryTree()
        {
            Add(null, null);
        }

        [Theory]
        [ClassData(typeof(InvertBinaryTree))]
        public void Invert_Given_BinaryTree(TreeNode input, TreeNode expectedResult)
        {
            var result = InvertTree(input);
            Assert.True(expectedResult.AreEqual(result));
        }

        public TreeNode InvertTree(TreeNode root)
        {

        }
    }
}
