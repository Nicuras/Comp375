using Microsoft.EntityFrameworkCore;
using BookAPI.Models;

namespace BookAPI.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Electronic> Electronics { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
