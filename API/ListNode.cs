using System.Collections.Generic;

namespace API
{
    public class ListNode : IEnumerable<int>
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public IEnumerator<int> GetEnumerator()
        {
            var node = this;
            while (node != null)
            {
                yield return node.val;
                node = node.next;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
