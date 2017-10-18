﻿// <auto-generated />
using EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EFCore.Data.Migrations
{
    [DbContext(typeof(MediaContext))]
    [Migration("20171018004714_Add_photo")]
    partial class Add_photo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Data.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("EFCore.Data.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Height");

                    b.Property<int?>("PhotographerId");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("PhotographerId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("EFCore.Data.Photo", b =>
                {
                    b.HasOne("EFCore.Data.People", "Photographer")
                        .WithMany()
                        .HasForeignKey("PhotographerId");

                    b.OwnsOne("EFCore.Data.Geolocation", "Geolocation", b1 =>
                        {
                            b1.Property<int>("PhotoId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<decimal?>("Lat");

                            b1.Property<decimal?>("Long");

                            b1.ToTable("Photos");

                            b1.HasOne("EFCore.Data.Photo")
                                .WithOne("Geolocation")
                                .HasForeignKey("EFCore.Data.Geolocation", "PhotoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
