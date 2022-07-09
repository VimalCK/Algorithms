using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Types
{
    public class ListNode
    {

        public int val { get; set; }
        public ListNode? next { get; set; }

        public ListNode(int headValue = 0, params int[] values)
        {
            this.val = headValue;
            var temp = this;
            foreach (var value in values)
            {
                temp.next = new ListNode(value);
                temp = temp.next;
            }
        }

        public ListNode Add(params int[] values)
        {
            var lastNode = GetLastNode();
            foreach (var item in values)
            {
                lastNode.next = new ListNode(item);
                lastNode = lastNode.next;
            }

            return this;
        }


        public ListNode Add(ListNode node)
        {
            var lastNode = GetLastNode();
            lastNode.next = node;

            return this;
        }

        private ListNode GetLastNode()
        {
            var temp = this;
            while (temp.next is not null)
            {
                temp = temp.next;
            }

            return temp;
        }
    }
}
