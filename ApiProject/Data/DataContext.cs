using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Owner> Owners { get; set; }

        
    }
}
