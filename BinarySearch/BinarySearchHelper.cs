using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinarySearch
{
    public static class BinarySearchHelper<T> where T: struct, IEquatable<T>, IComparable<T>
    {
        public static int? Search(T[] array, T item, int iterationNumber = 0)
        {
            // Let's allow users passing unordered array.
            // array = array.OrderBy(x => x).ToArray();

            var commaSeparatedArrayItems = string.Join(",", array.Select(x => x.ToString()));
            Debug.WriteLine($"Array: [{commaSeparatedArrayItems}].");

            int low = 0;
            int high = array.Length - 1;

            while (low < high)
            {
                int mid = (low + high) / 2;
                var possibleValue = array[mid];
                var comparisonResult = item.CompareTo(possibleValue);
                T[] newArray = null;

                Debug.WriteLine(
                    $"Start doing {++iterationNumber} iteration. Position: {mid}. Possible value: {possibleValue.ToString()}. Comparison result: {comparisonResult}.");

                if (comparisonResult == 0)
                {
                    Debug.WriteLine($"The item was found! It's {possibleValue}.");
                    return mid;
                }
                else if (comparisonResult < 0) // The instance precedes
                {
                    high = mid - 1;
                    newArray = array.Take(high - low).ToArray();
                }
                else // The instance follows
                {
                    low = mid + 1;
                    newArray = array.Skip(mid).Take(high - low).ToArray();
                }

                return Search(newArray, item, iterationNumber);
            }

            Debug.WriteLine("The item was not found in the array!");
            return null;
        }
    }
}
