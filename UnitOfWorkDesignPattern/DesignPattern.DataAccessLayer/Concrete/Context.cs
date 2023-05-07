using DesignPattern.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=EGEMEN\\SQLEXPRESS; initial catalog=DesignPattern3; integrated security=true;");
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Process> Processes { get; set; }
    }
}
