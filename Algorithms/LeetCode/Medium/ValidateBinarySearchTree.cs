using Algorithms.Types;
using System;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Given the root of a binary tree, determine if it is a valid binary search tree (BST). 
     * A valid BST is defined as follows:
     *      The left subtree of a node contains only nodes with keys less than the node's key.
     *      The right subtree of a node contains only nodes with keys greater than the node's key.
     *      Both the left and right subtrees must also be binary search trees.
     *      
     *              Correct                 Incorrect
     *              
     *                  2                       5
     *                 / \                     / \
     *                1   3                   1   4
     *                                           / \
     *                                          3   6
     */
    public class ValidateBinarySearchTree : TheoryData<TreeNode, bool>
    {
        public ValidateBinarySearchTree()
        {
            Add(new TreeNode(new int?[] { 5, 4, 6, null, null, 3, 7 }), false);
            Add(new TreeNode(new int?[] { 0 }), true);
            Add(new TreeNode(new int?[] { 2, 2, 2 }), false);
            Add(new TreeNode(new int?[] { 2, 1, 3 }), true);
            Add(new TreeNode(new int?[] { 5, 1, 4, null, null, 3, 6 }), false);
        }

        [Theory]
        [ClassData(typeof(ValidateBinarySearchTree))]
        public void ReturnTrueIfBinarySearchTreeIsValid(TreeNode node, bool expectedResult)
        {
            var result = IsValidBST(node);

            Assert.Equal(expectedResult, result);
        }

        public bool IsValidBST(TreeNode? root)
        {
            return IsValid(root, null, null);
        }

        public bool IsValid(TreeNode? root, int? high, int? low)
        {
            if (root is null)
            {
                return true;
            }

            if ((high != null && root.val >= high) || (low != null && root.val <= low))
            {
                return false;
            }

            return IsValid(root.left, root.val, low) && IsValid(root.right, high, root.val);
        }
    }
}
