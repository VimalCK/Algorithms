using Algorithms.Types;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Given the root of a Binary Search Tree and a target number k, return true if there exist two elements in 
     * the BST such that their sum is equal to the given target.
     *  
     *                                          5
     *                                         / \
     *                                        3   6
     *                                       / \   \
     *                                      2   4   7
     *                                      
     *                                      Target number : 9
     *                                      Expected Result : true (5 + 4)
     */
    public class TwoSumInputAsBST : TheoryData<TreeNode, int, bool>
    {
        public TwoSumInputAsBST()
        {
            Add(new TreeNode(new int?[] { 5, 3, 6, 2, 4, null, 7 }), 9, true);
        }

        [Theory]
        [ClassData(typeof(TwoSumInputAsBST))]
        public void Return_True_If_TwoElementsInBST_meet_the_target(TreeNode root, int target, bool expectedResult)
        {
            var result = FindTarget(root, target);

            Assert.Equal(expectedResult, result);
        }

        public bool FindTarget(TreeNode root, int k)
        {
            if (root is null)
            {
                return false;
            }

            var queue = new Queue<TreeNode>();
            var elements = new HashSet<int>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var temp = k - node.val;
                if (elements.Contains(temp))
                {
                    return true;
                }

                elements.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            return false;

        }
    }
}
