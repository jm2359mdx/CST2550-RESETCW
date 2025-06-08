using System;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;
using System.Collections.Generic;

namespace LibraryManagementSystem.Database
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LibraryDb;Trusted_Connection=True;");
        }
    }
}
