using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * You are given the root of a binary search tree (BST) and an integer val. Find the node in the BST that the node's value 
     * equals val and return the subtree rooted with that node. If such a node does not exist, return null.
     *          
     *                                      4
     *                                     / \
     *                                    2   7
     *                                   / \
     *                                  1   3
     *                                  
     *                                 Value = 2
     *                                 Result = 2 - 1 - 3
     */
    public class SearchInaBinarySearchTree : TheoryData<TreeNode, int, TreeNode>
    {
        public SearchInaBinarySearchTree()
        {
            Add(new TreeNode(new int?[] { 4, 2, 7, 1, 3 }), 2, new TreeNode(new int?[] { 2, 1, 3 }));
        }

        [Theory]
        [ClassData(typeof(SearchInaBinarySearchTree))]
        public void Return_SubTree_If_Value_Found(TreeNode root, int value, TreeNode expectedResult)
        {
            var result = SearchBST(root, value);

            Assert.True(result.AreEqual(expectedResult));
        }

        public TreeNode? SearchBST(TreeNode? root, int val)
        {
            if (root is null || root.val == val)
            {
                return root;
            }

            return SearchBST(root.left, val) ?? SearchBST(root.right, val);
        }
    }
}
