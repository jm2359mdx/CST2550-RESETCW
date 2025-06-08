using System;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.DataStructures;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestCustomList();
            TestCustomHashTable();
            TestLibraryService();
            TestDbCrud();


            LibraryManagementSystem.Tests.SearchTests.Run();

            Console.ReadLine();
        }

        static void TestCustomList()
        {
            var resources = new CustomList<Resource>();

            resources.Add(new Resource { Id = 1, Title = "Book A", Author = "Author A", PublicationYear = 2021, Genre = "Genre A", IsAvailable = true });
            resources.Add(new Resource { Id = 2, Title = "Book B", Author = "Author B", PublicationYear = 2022, Genre = "Genre B", IsAvailable = false });

            Console.WriteLine("Testing CustomList:");
            for (int i = 0; i < resources.Count; i++)
            {
                var res = resources.Get(i);
                Console.WriteLine($"- [{res.Id}] {res.Title}, Available: {res.IsAvailable}");
            }

            resources.RemoveAt(0);
            Console.WriteLine("After removing first resource from CustomList:");
            for (int i = 0; i < resources.Count; i++)
            {
                var res = resources.Get(i);
                Console.WriteLine($"- [{res.Id}] {res.Title}, Available: {res.IsAvailable}");
            }
            Console.WriteLine();
        }

        static void TestCustomHashTable()
        {
            var resourceTable = new CustomHashTable<int, Resource>();

            resourceTable.Add(1, new Resource { Id = 1, Title = "Book A", Author = "Author A", IsAvailable = true });
            resourceTable.Add(2, new Resource { Id = 2, Title = "Book B", Author = "Author B", IsAvailable = false });

            Console.WriteLine("Testing CustomHashTable:");
            Console.WriteLine($"- Resource ID 1: {resourceTable.Get(1).Title}");
            Console.WriteLine($"- Resource ID 2: {resourceTable.Get(2).Title}");
            Console.WriteLine();
        }

        static void TestLibraryService()
        {
            var library = new LibraryService();

            library.AddResource(new Resource { Id = 101, Title = "C# Basics", Author = "John Doe", PublicationYear = 2020, Genre = "Programming", IsAvailable = true });
            library.AddResource(new Resource { Id = 102, Title = "Advanced Databases", Author = "Jane Smith", PublicationYear = 2021, Genre = "Database", IsAvailable = false });

            Console.WriteLine("Testing LibraryService (initial resources):");
            library.DisplayAllResources();

            library.UpdateResource(101, new Resource { Id = 101, Title = "C# Advanced", Author = "John Doe", PublicationYear = 2022, Genre = "Programming", IsAvailable = true });
            Console.WriteLine("\nLibraryService after updating resource ID 101:");
            library.DisplayAllResources();

            library.RemoveResource(102);
            Console.WriteLine("\nLibraryService after removing resource ID 102:");
            library.DisplayAllResources();

            // 🔄 Borrowing Test - Add and Display Records
            var borrowRecord = new BorrowingRecord
            {
                ResourceId = 1, // make sure this ID exists in your Resources table
                BorrowerName = "Alice",
                BorrowedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7)
            };

            library.AddBorrowingRecord(borrowRecord);
            library.DisplayAllBorrowingRecords();



            Console.WriteLine();

        }

        static void TestDbCrud()
        {
            var dbService = new LibraryService();

            var newRes = new Resource
            {
               
                Title = "EF Core Guide",
                Author = "Microsoft",
                PublicationYear = 2023,
                Genre = "Tutorial",
                IsAvailable = true
            };

            dbService.AddResourceToDb(newRes);
            dbService.DisplayAllResourcesFromDb();
            dbService.UpdateResourceInDb(new Resource { Title = "EF Core Updated", Author = "Microsoft", PublicationYear = 2024, Genre = "Tutorial", IsAvailable = true });
            dbService.DisplayAllResourcesFromDb();
            dbService.DeleteResourceFromDb(300);
        }

    }
}
