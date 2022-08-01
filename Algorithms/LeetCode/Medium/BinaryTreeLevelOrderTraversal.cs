using Algorithms.Types;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.LeetCode.Medium
{
    /*
     * Given the root of a binary tree, return the level order traversal of its nodes' values. 
     * (i.e., from left to right, level by level). 
     *                  
     *                              3
     *                             / \
     *                            9   20
     *                                / \
     *                               15  7
     */
    public class BinaryTreeLevelOrderTraversal : TheoryData<TreeNode?, IList<IList<int>>>
    {
        public BinaryTreeLevelOrderTraversal()
        {
            //Add(new TreeNode(new int?[] { 3, 9, 20, null, null, 15, 7 }), new int[][]
            //{
            //   new int[] { 3 },
            //   new int[] { 9, 20 },
            //   new int[] { 15, 7 },
            //});

            //Add(new TreeNode(new int?[] { 1 }), new int[][] { new int[] { 1 } });
            Add(null, new int[][] { new int[] { } });
        }

        [Theory]
        [ClassData(typeof(BinaryTreeLevelOrderTraversal))]
        public void ReturnLevelOrderTraversalOfNodes(TreeNode node, IList<IList<int>> expectedResult)
        {
            var result = LevelOrder(node);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.True(expectedResult[i].AreEqual(result[i]));
            }
        }

        Dictionary<int, IList<int>> result = new Dictionary<int, IList<int>>();

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            TraverseTreeNode(root, 0);
            return result.Values.ToArray();
        }

        private void TraverseTreeNode(TreeNode? node, int level)
        {
            if (node is null)
            {
                return;
            }

            if (!result.ContainsKey(level))
            {
                result.Add(level, new List<int>());
            }

            result[level].Add(node.val);
            TraverseTreeNode(node?.left, level + 1);
            TraverseTreeNode(node?.right, level + 1);
        }
    }
}
