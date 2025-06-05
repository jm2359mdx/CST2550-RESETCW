using System;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Tests
{
    public class SearchTests
    {
        public static void Run()
        {
            var library = new LibraryService();

            // Prepare data
            library.AddResource(new Resource { Id = 1, Title = "C# Programming", Author = "John", PublicationYear = 2020, Genre = "Tech", IsAvailable = true });
            library.AddResource(new Resource { Id = 2, Title = "Databases", Author = "Jane", PublicationYear = 2021, Genre = "Tech", IsAvailable = false });
            library.AddResource(new Resource { Id = 3, Title = "Networking", Author = "Alice", PublicationYear = 2022, Genre = "IT", IsAvailable = true });

            Console.WriteLine("🔎 Running Search Tests:");

            var linear = library.LinearSearchByTitle("Databases");
            Console.WriteLine($"Linear Search: {(linear != null ? $"Found {linear.Title}" : "Not Found")}");

            library.AddToHash(new Resource { Id = 1, Title = "C# Programming" });
            var hash = library.HashSearchById(1);
            Console.WriteLine($"Hash Search: {(hash != null ? $"Found {hash.Title}" : "Not Found")}");

            var binary = library.BinarySearchByTitle("Networking");
            Console.WriteLine($"Binary Search: {(binary != null ? $"Found {binary.Title}" : "Not Found")}");
        }
    }
}
