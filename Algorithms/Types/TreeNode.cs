using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Types
{
    public class TreeNode
    {
        public int? val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int? val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public TreeNode(int?[] values)
        {
            var queue = new Queue<int?>(values);
            var nodes = new Queue<TreeNode>();

            TreeNode root = this;
            if (!queue.TryDequeue(out var result))
            {
                return;
            }

            root.val = result;
            nodes.Enqueue(root);

            while (nodes.Any())
            {
                var temp = nodes.Dequeue();
                if (queue.TryDequeue(out result) && result is not null)
                {
                    temp.left = new TreeNode(result);
                    nodes.Enqueue(temp.left);
                }

                if (queue.TryDequeue(out result) & result is not null)
                {
                    temp.right = new TreeNode(result);
                    nodes.Enqueue(temp.right);
                }
            }
        }

    }
}
