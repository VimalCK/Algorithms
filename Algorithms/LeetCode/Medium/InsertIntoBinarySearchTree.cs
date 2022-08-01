using Algorithms.Types;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * You are given the root node of a binary search tree (BST) and a value to insert into the tree. Return the root node 
     * of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.
     * Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. 
     * You can return any of them.
     * 
     *              4                           4
     *             / \                         / \
     *            2   7                       2   7
     *           / \                         / \  /  
     *          1   3                       1   3 5
     * 
     */
    public class InsertIntoBinarySearchTree : TheoryData<TreeNode?, int, TreeNode?>
    {
        public InsertIntoBinarySearchTree()
        {
            Add(null, 5, new TreeNode(5));
            Add(new TreeNode(new int?[] { 4, 2, 7, 1, 3 }), 5, new TreeNode(new int?[] { 4, 2, 7, 1, 3, 5 }));
            Add(new TreeNode(new int?[] { 40, 20, 60, 10, 30, 50, 70 }), 25, new TreeNode(new int?[] { 40, 20, 60, 10, 30, 50, 70, null, null, 25 }));
            Add(new TreeNode(new int?[] { 4, 2, 7, 1, 3, null, null, null, null, null, null }), 5, new TreeNode(new int?[] { 4, 2, 7, 1, 3, 5 }));
            Add(new TreeNode(new int?[] { 61, 46, 66, 43, null, null, null, 39, null, null, null }), 88, new TreeNode(new int?[] { 61, 46, 66, 43, null, null, 88, 39 }));
        }

        [Theory]
        [ClassData(typeof(InsertIntoBinarySearchTree))]
        public void InsertValueIntoBinaryTree(TreeNode root, int val, TreeNode expectedResult)
        {
            var result = InsertIntoBST(root, val);

            Assert.True(result.AreEqual(expectedResult));
        }

        public TreeNode? InsertIntoBST(TreeNode? root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }

            if (val <= root.val)
            {
                root.left = InsertIntoBST(root?.left, val);
            }
            else
            {
                root.right = InsertIntoBST(root?.right, val);
            }

            return root;
        }
    }
}
