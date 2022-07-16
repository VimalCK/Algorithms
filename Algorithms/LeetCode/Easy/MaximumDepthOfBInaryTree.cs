using Algorithms.Types;
using System;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a binary tree, return its maximum depth. A binary tree's maximum depth is the number of 
     * nodes along the longest path from the root node down to the farthest leaf node.
     *                      3
     *                     / \
     *                    9  20
     *                      /  \
     *                     15   7
     */
    public class MaximumDepthOfBInaryTree : TheoryData<TreeNode, int>
    {
        public MaximumDepthOfBInaryTree()
        {
            Add(new TreeNode(1, new TreeNode(2)), 2);
            //Add(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))), 3);
        }

        [Theory]
        [ClassData(typeof(MaximumDepthOfBInaryTree))]
        public void Return_Maximum_Depth_Of_BinaryTree(TreeNode node, int expectedResult)
        {
            var result = MaxDepth(node);
            Assert.Equal(expectedResult, result);
        }

        public int MaxDepth(TreeNode? root)
        {
            if (root == null)
            {
                return 0;
            }


            var leftDepth = MaxDepth(root.left);
            var rightDepth = MaxDepth(root.right);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
