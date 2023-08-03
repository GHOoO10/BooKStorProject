using GhamdanAlYamaniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GhamdanAlYamaniProject.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Books> Book { get; set; }
        public DbSet<Catagory> Catagorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<BookStor> BookStors { get; set; }
    }
}
