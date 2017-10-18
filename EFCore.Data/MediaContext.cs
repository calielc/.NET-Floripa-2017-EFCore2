﻿using Microsoft.EntityFrameworkCore;

namespace EFCore.Data {

    public class MediaContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=EFCore.Data;User id=sa;Password=password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}