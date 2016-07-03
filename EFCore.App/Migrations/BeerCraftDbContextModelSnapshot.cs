using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore.App.Database;

namespace EFCore.App.Migrations
{
    [DbContext(typeof(BeerCraftDbContext))]
    partial class BeerCraftDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.App.Database.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("ABV");

                    b.Property<int?>("CraftId");

                    b.Property<double?>("IBU");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CraftId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("EFCore.App.Database.Craft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Crafts");
                });

            modelBuilder.Entity("EFCore.App.Database.Beer", b =>
                {
                    b.HasOne("EFCore.App.Database.Craft", "Craft")
                        .WithMany("Beers")
                        .HasForeignKey("CraftId");
                });
        }
    }
}
