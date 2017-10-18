using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EFCore.Data {

    public class MediaContext : DbContext {
        public MediaContext(DbContextOptions options) : base(options) {
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PeopleConfiguration());

            modelBuilder.Entity<Photo>().OwnsOne(x => x.Geolocation);

            modelBuilder.Entity<Video>().OwnsOne(x => x.Geolocation).ToTable("VideoGeolocations");
        }
    }

    class PeopleConfiguration : IEntityTypeConfiguration<People> {
        public void Configure(EntityTypeBuilder<People> builder) {
            builder.HasQueryFilter(x => x.DeletedAt == null);
        }
    }
}
