using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class LibraryTrackingSystemContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LibraryTrackingSystem;Trusted_Connection=true");

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
    }
}
