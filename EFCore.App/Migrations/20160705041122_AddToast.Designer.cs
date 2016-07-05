using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore.App.Database;

namespace EFCore.App.Migrations
{
    [DbContext(typeof(BeerCraftDbContext))]
    [Migration("20160705041122_AddToast")]
    partial class AddToast
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Logo");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CraftId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("EFCore.App.Database.Craft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Logo");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Crafts");
                });

            modelBuilder.Entity("EFCore.App.Database.Toast", b =>
                {
                    b.Property<int>("ToastId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BeerId")
                        .IsRequired();

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double>("Nota")
                        .HasColumnName("Grade");

                    b.HasKey("ToastId");

                    b.HasIndex("BeerId");

                    b.ToTable("Toast");
                });

            modelBuilder.Entity("EFCore.App.Database.Beer", b =>
                {
                    b.HasOne("EFCore.App.Database.Craft", "Craft")
                        .WithMany("Beers")
                        .HasForeignKey("CraftId");
                });

            modelBuilder.Entity("EFCore.App.Database.Toast", b =>
                {
                    b.HasOne("EFCore.App.Database.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
