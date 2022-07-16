using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a binary tree, return the postorder traversal of its nodes' values.
     *                         1
     *                        / \
     *                       2   3
     *                      / \
     *                     4   5
     */
    public class BinaryTreePostOrderTraversal : TheoryData<TreeNode, int[]>
    {
        public BinaryTreePostOrderTraversal()
        {
            Add(null, new int[] { });
            Add(new TreeNode(1), new int[] { 1 });
            Add(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))), new int[] { 3, 2, 1 });
            Add(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3)), new int[] { 4, 5, 2, 3, 1 });
        }

        [Theory]
        [ClassData(typeof(BinaryTreePostOrderTraversal))]
        public void ReturnTreeNodeValuesInPostOrderTraversal(TreeNode root, int[] expectedResult)
        {
            var result = PostorderTraversal(root);

            Assert.True(result.AreEqual(expectedResult));
        }

        public IList<int> PostorderTraversal(TreeNode? root)
        {
            if (root == null)
            {
                return new int[] { };
            }

            var result = new List<int>();
            result.AddRange(PostorderTraversal(root.left));
            result.AddRange(PostorderTraversal(root.right));
            result.Add(root.val);
            return result;

        }
    }
}
