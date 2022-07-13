using Algorithms.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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

        public static bool AreEqual<T>(this T[] array, T[] values)
        {
            if (array.Length != values.Length)
            {
                return false;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (!object.Equals(array[i], values[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
