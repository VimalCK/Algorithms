using Algorithms.Types;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that 
     * adding up all the values along the path equals targetSum. A leaf is a node with no children.
     *                                             5
     *                                            / \
     *                                           /   \
     *                                          4     8
     *                                         /     / \
     *                                        11    13  4
     *                                       /  \        \
     *                                      7    2        1
     *                                      
     *       Target = 22;  Path = 5 --> 4 --> 11 --> 2 = 22
     */
    public class PathSum : TheoryData<TreeNode, int, bool>
    {
        public PathSum()
        {
            Add(new TreeNode(new int?[] { -2, null, -3 }), -5, true);
            Add(new TreeNode(new int?[] { 1, 2 }), 1, false);
            Add(new TreeNode(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 }), 22, true);
        }

        [Theory]
        [ClassData(typeof(PathSum))]
        public void ReturnPathFromTreeNode(TreeNode node, int target, bool expectedResult)
        {
            var result = HasPathSum(node, target);

            Assert.Equal(expectedResult, result);
        }

        public bool HasPathSum(TreeNode? root, int targetSum)
        {
            if (root is null)
            {
                return false;
            }

            targetSum -= root.val;
            if (targetSum == 0 && (root.left is null && root.right is null))
            {
                return true;
            }

            return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
        }
    }
}
