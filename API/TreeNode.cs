using System;
using System.Collections.Generic;
using System.Linq;

namespace API
{
    public class TreeNode
    {
        public static TreeNode Build(int?[] input)
        {
            if (input == null || input.Length == 0 || input[0] == null) return null;

            var nodes = input.Select(x => x == null ? null : new TreeNode(x.Value)).ToList();
            for (int i = 0; i < nodes.Count(); i++)
            {
                var node = nodes[i];
                if (node == null) continue;

                var j = 2 * i + 1;
                if (j < nodes.Count)
                {
                    node.left = nodes[j++];
                }
                if (j < nodes.Count)
                {
                    node.right = nodes[j];
                }
            }

            return nodes[0];
        }

        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
