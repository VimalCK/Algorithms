using Algorithms.Types;
using System;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
     *                                          1
     *                                        /   \
     *                                       2     2
     *                                      / \    /\
     *                                     3   4  3  4
     */
    public class SymmetricTree : TheoryData<TreeNode, bool>
    {
        public SymmetricTree()
        {
            //Add(new(1, new(2, new(3), new(4)), new(2, new(3), new(4))), true);
            Add(new(1, new(2, null, new(3)), new TreeNode(2, null, new(3))), false);
            // Add(new(1, new(0), null), false);
        }

        [Theory]
        [ClassData(typeof(SymmetricTree))]
        public void Return_True_If_TreeNode_Is_Symmetric(TreeNode root, bool exprectedResult)
        {
            var result = IsSymmetric(root);

            Assert.Equal(exprectedResult, result);
        }

        public bool IsSymmetric(TreeNode root)
        {
            return isMirror(root, root);
        }

        public bool isMirror(TreeNode? node1, TreeNode? node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            return (node1.val == node2.val) && isMirror(node1.right, node2.left) && isMirror(node1.left, node2.right);
        }
    }
}
