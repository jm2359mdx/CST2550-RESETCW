using System;
using LibraryManagementSystem.DataStructures;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class LibraryService
    {
        private readonly CustomList<Resource> _resources;

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
