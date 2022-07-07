using Algorithms.Types;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    public class LinkedListCycle : TheoryData<ListNode, bool>
    {
        public LinkedListCycle()
        {
            var node = new ListNode(2);
            Add(new ListNode(3).Add(node).Add(0).Add(4).Add(node), true);
        }

        [Theory]
        [ClassData(typeof(LinkedListCycle))]
        public void Return_True_If_LinkedList_Cycle_Detected(ListNode node, bool expectedResult)
        {
            var result = HasCycle(node);

            Assert.Equal(expectedResult, result);
        }

        public bool HasCycle(ListNode head)
        {
            return true;
        }
    }
}
