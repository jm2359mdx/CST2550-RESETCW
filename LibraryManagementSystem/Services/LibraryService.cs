using System;
using LibraryManagementSystem.DataStructures;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class LibraryService
    {
        private readonly CustomList<Resource> _resources;
        private CustomHashTable<int, Resource> _resourceHash = new();


        public LibraryService()
        {
            _resources = new CustomList<Resource>();
        }

        // Add a new Resource
        public void AddResource(Resource resource)
        {
            _resources.Add(resource);
        }

        // Remove Resource by ID
        public bool RemoveResource(int resourceId)
        {
            for (int i = 0; i < _resources.Count; i++)
            {
                if (_resources.Get(i).Id == resourceId)
                {
                    _resources.RemoveAt(i);
                    return true; // Successfully removed
                }
            }
            return false; // Not found
        }

        // Update Resource by ID
        public bool UpdateResource(int resourceId, Resource updatedResource)
        {
            for (int i = 0; i < _resources.Count; i++)
            {
                if (_resources.Get(i).Id == resourceId)
                {
                    _resources.RemoveAt(i);
                    _resources.Add(updatedResource);
                    return true; // Successfully updated
                }
            }
            return false; // Not found
        }

        // Get Resource by ID
        public Resource GetResource(int resourceId)
        {
            for (int i = 0; i < _resources.Count; i++)
            {
                var resource = _resources.Get(i);
                if (resource.Id == resourceId)
                    return resource;
            }
            throw new Exception("Resource not found");
        }


        public void AddToHash(Resource resource)
        {
            _resourceHash.Add(resource.Id, resource);
        }

        public Resource HashSearchById(int id)
        {
            return _resourceHash.Get(id);
        }


        public Resource BinarySearchByTitle(string title)
        {
            // Step 1: Convert CustomList to a standard List<Resource>
            var sortedList = new List<Resource>();
            for (int i = 0; i < _resources.Count; i++)
            {
                sortedList.Add(_resources.Get(i));
            }


            // Step 2: Sort alphabetically by Title
            sortedList.Sort((a, b) => a.Title.CompareTo(b.Title));

            // Step 3: Perform binary search
            int left = 0, right = sortedList.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int cmp = sortedList[mid].Title.CompareTo(title);

                if (cmp == 0)
                    return sortedList[mid];
                else if (cmp < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null; // Not found
        }



        //
        public Resource LinearSearchByTitle(string title)
        {
            for (int i = 0; i < _resources.Count; i++)
            {
                var res = _resources.Get(i);
                if (res.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return res;
            }
            return null;
        }


        // Display all resources
        public void DisplayAllResources()
        {
            Console.WriteLine("Current Resources:");
            for (int i = 0; i < _resources.Count; i++)
            {
                var res = _resources.Get(i);
                Console.WriteLine($"- [{res.Id}] {res.Title} by {res.Author}, Year: {res.PublicationYear}, Available: {res.IsAvailable}");
            }
        }
    }
}
