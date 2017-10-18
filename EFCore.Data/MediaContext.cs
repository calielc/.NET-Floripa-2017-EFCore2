using Microsoft.EntityFrameworkCore;

namespace EFCore.Data {

    public class MediaContext : DbContext {
        public DbSet<People> Peoples { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=EFCore.Data;User id=sa;Password=password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<People>().HasQueryFilter(x => x.DeletedAt == null);

            modelBuilder.Entity<Photo>().OwnsOne(x => x.Geolocation);

            modelBuilder.Entity<Video>().OwnsOne(x => x.Geolocation).ToTable("VideoGeolocations");
        }
    }
}
