using Algorithms.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class ExtensionMethods
    {
        public static bool AreEqual(this ListNode? node1, ListNode? node2)
        {
            while (node1 != null || node2 != null)
            {
                if (node1?.val != node2?.val)
                {
                    return false;
                }

                node1 = node1?.next;
                node2 = node2?.next;
            }

            return true;
        }

        public static bool AreEqual<T>(this IEnumerable<T> array, IEnumerable<T> values)
        {
            return array.Count() != values.Count() ? false : array.SequenceEqual(values);
        }
    }
}
