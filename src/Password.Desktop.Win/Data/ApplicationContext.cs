﻿using Microsoft.EntityFrameworkCore;
using Password.Desktop.Win.Data.Configurations;
using Password.Desktop.Win.Data.Migration;
using Password.Desktop.Win.Model;

namespace Password.Desktop.Win.Data
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<PasswordInfo> PasswordInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PasswordDataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PasswordInfoConfiguration());
            builder.UseMigrationsHistory();
            base.OnModelCreating(builder);
        }
    }
}