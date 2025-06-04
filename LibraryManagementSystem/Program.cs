using System;
using LibraryManagementSystem.DataStructures;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new CustomList<string>();

            list.Add("Book A");
            list.Add("Book B");
            list.Add("Book C");

            Console.WriteLine("Items in list:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"- {list.Get(i)}");
            }

            Console.WriteLine("Removing index 1 (Book B)");
            list.RemoveAt(1);

            Console.WriteLine("After removal:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"- {list.Get(i)}");
            }

            Console.ReadLine(); // Optional: Keeps the window open
        }
    }
}
