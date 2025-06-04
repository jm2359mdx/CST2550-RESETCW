using System;

namespace LibraryManagementSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }  // Unique ID
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
