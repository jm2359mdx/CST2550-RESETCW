using System;

namespace LibraryManagementSystem.Models
{
    public class BorrowingRecord
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
