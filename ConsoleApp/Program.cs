using System;
using System.Linq;
using BinarySearch;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============== Algorithms ==============");

            var value1 = 41;
            var value2 = 4921;
            var array = new[] { 1, 5, 6, 5, 89, 8, 51, 5, 8, value2, 95, 6, 4, 1265, 4596, 165, 49, value1, 6594 };
            array = array.OrderBy(x => x).ToArray();

            var result = BinarySearchHelper<int>.Search(array, value2);

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey();
        }
    }
}
