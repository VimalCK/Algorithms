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

        public ListNode(int val = 0) => this.val = val;

        public ListNode Add(int value) => Add(new ListNode(value));

        public ListNode Add(ListNode node)
        {
            next = node;
            return next;
        }
    }
}
