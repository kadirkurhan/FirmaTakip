using FirmaTakip.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Contexts
{
    public class FirmaTakipContext:IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DELL_PC\\SQLEXPRESS;database=FirmaTakipDb;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(I => I.CompanyCategories)
                .WithOne(I => I.Company)
                .HasForeignKey(I => I.CompanyId);

            modelBuilder.Entity<Category>()
                .HasMany(I => I.CompanyCategories)
                .WithOne(I => I.CategoryName)
                .HasForeignKey(I => I.CategoryId);

            modelBuilder.Entity<CompanyCategory>().HasKey(I => I.Id);
            modelBuilder.Entity<CompanyCategory>().HasIndex(I => new
            {
                I.CategoryId,
                I.CompanyId
            }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<MailAccount> MailAccounts { get; set; }

        public DbSet<Note> Notes { get; set; }


    }
}
