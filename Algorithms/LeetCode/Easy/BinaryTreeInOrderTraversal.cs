using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a binary tree, return the inorder traversal of its nodes' values.
     *                         1
     *                        / \
     *                       2   3
     *                      / \
     *                     4   5
     *                     
     *                     4 - 2 - 5 - 1 - 3
     */
    public class BinaryTreeInOrderTraversal : TheoryData<TreeNode?, int?[]>
    {
        public BinaryTreeInOrderTraversal()
        {
            Add(null, new int?[] { });
            Add(new TreeNode(1), new int?[] { 1 });
            Add(new TreeNode(new int?[] { 1, null, 2, 3 }), new int?[] { 1, 3, 2 });
            Add(new TreeNode(new int?[] { 1, 2, 3, 4, 5 }), new int?[] { 4, 2, 5, 1, 3 });
        }

        [Theory]
        [ClassData(typeof(BinaryTreeInOrderTraversal))]
        public void ReturnValuesUsingInorderTraversal(TreeNode root, int?[] expectedResult)
        {
            var result = InorderTraversal(root);

            Assert.True(ExtensionMethods.AreEqual<int?>(result, expectedResult));
        }

        public IList<int?> InorderTraversal(TreeNode? root)
        {
            if (root == null)
            {
                return new List<int?>();
            }

            var result = new List<int?>();
            result.AddRange(InorderTraversal(root.left));
            result.Add(root.val);
            result.AddRange(InorderTraversal(root.right));

            return result;
        }
    }
}
