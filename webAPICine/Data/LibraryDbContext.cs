using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPICine.Data.Entities;

namespace VideoGameAPI.Data
{
    public class LibraryDbContext : IdentityDbContext
    {
        public DbSet<CineEntity> Cines { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CineEntity>().ToTable("Cines");
            modelBuilder.Entity<CineEntity>().Property(c => c.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CineEntity>().HasMany(c => c.Movies).WithOne(v => v.Cine);

            modelBuilder.Entity<MovieEntity>().ToTable("Movies");
            modelBuilder.Entity<MovieEntity>().Property(v => v.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MovieEntity>().HasOne(v => v.Cine).WithMany(c => c.Movies);
        }


        //dotnet tool install --global dotnet-ef
        //dotnet ef migrations add InitialCreate
        //dotnet ef database update

    }
}
