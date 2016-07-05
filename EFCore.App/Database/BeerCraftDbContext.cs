using Microsoft.EntityFrameworkCore;

namespace EFCore.App.Database
{
    public class BeerCraftDbContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Craft> Crafts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=EFCore.Cmd.NewDb;User id=sa;Password=password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Craft>().Property(craft => craft.Name).IsRequired();

            modelBuilder.Entity<Toast>().Property(x => x.DateTime).IsRequired();
        }
    }
}
