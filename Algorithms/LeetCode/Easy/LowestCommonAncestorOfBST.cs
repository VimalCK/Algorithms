using Algorithms.Types;
using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST. 
     * According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes 
     * p and q as the lowest node in T that has both p and q as descendants 
     * (where we allow a node to be a descendant of itself).”
     * 
     *                                           6
     *                                          / \
     *                                         /   \
     *                                        2     8
     *                                       / \   / \
     *                                      0   4 7   9
     *                                         / \
     *                                        3   5
     *                                         
     */
    public class LowestCommonAncestorOfBST : TheoryData<TreeNode, int, int, int>
    {
        public LowestCommonAncestorOfBST()
        {
            Add(new TreeNode(new int?[] { 2, 1, 3 }), 3, 1, 2);
            Add(new TreeNode(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 }), 0, 5, 2);
            Add(new TreeNode(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 }), 2, 8, 6);
        }

        [Theory]
        [ClassData(typeof(LowestCommonAncestorOfBST))]
        public void Return_Lowest_Common_Ancestor_OfA_BinaryTree(TreeNode root, int p, int q, int expected)
        {
            var pNode = root.GetNode(p);
            var qNode = root.GetNode(q);
            var expectedNode = root.GetNode(expected);
            var result = LowestCommonAncestor(root, pNode, qNode);

            Assert.Equal(expectedNode?.val, result?.val);
        }

        public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode? p, TreeNode? q)
        {
            if (root == null || (root.val == p?.val || root.val == q?.val))
            {
                return root;
            }

            var leftNode = LowestCommonAncestor(root.left, p, q);
            var rightNode = LowestCommonAncestor(root.right, p, q);
            var matchValues = new HashSet<int?>(new int?[] { p?.val, q?.val });

            return (leftNode != null && rightNode != null) &&
                matchValues.Contains(leftNode.val) &&
                matchValues.Contains(rightNode.val) ? root : leftNode ?? rightNode;
        }
    }
}
