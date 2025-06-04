using System;

namespace LibraryManagementSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }             // Unique ID
        public string Title { get; set; }       // Title of the resource
        public string Author { get; set; }      // Author or Creator
        public int PublicationYear { get; set; }// Year published
        public string Genre { get; set; }       // Genre or Category
        public bool IsAvailable { get; set; }   // Availability status (true/false)
    }
}
