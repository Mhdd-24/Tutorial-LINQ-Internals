using System;
using System.Linq;

namespace LinqInternals
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Using built-in Where
            var evenItem = items.NewWhere(x => x % 2 == 0);

            foreach (var item in evenItem)
            {
                Console.WriteLine(item);
            }
        }
    }
}
