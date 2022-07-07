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

        public int Value { get; set; }
        public ListNode? Next { get; set; }

        public ListNode(int val = 0) => this.Value = val;

        public ListNode Add(int value) => Add(new ListNode(value));

        public ListNode Add(ListNode node)
        {
            Next = node;
            return this;
        }
    }
}
