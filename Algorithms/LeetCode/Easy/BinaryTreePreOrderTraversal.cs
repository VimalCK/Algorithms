using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a binary tree, return the preorder traversal of its nodes' values.
     */
    public class BinaryTreePreOrderTraversal : TheoryData<TreeNode, IList<int>>
    {
        public BinaryTreePreOrderTraversal()
        {
            Add(null, new int[] { });
            Add(new TreeNode(1), new int[] { 1 });
            Add(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))), new int[] { 1, 2, 3 });
        }

        [Theory]
        [ClassData(typeof(BinaryTreePreOrderTraversal))]
        public void MyTheory(TreeNode root, IList<int> expectedResult)
        {
            var result = PreorderTraversal(root);

            Assert.True(result.AreEqual(expectedResult));
        }

        public IList<int> PreorderTraversal(TreeNode? root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return new int[] { };
            }

            result.Add(root.val);
            result.AddRange(PreorderTraversal(root.left));
            result.AddRange(PreorderTraversal(root.right));
            return result;
        }
    }
}
