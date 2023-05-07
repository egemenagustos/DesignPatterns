using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-B847571; initial catalog=DesignPattern4; integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
