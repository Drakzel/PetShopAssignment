using Microsoft.EntityFrameworkCore;
using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Infrastructure.Data
{
    public class PetShop2018Context : DbContext
    {
        public PetShop2018Context(DbContextOptions<PetShop2018Context> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Maps the relations between entities
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PreviousOwner)
                .WithMany(o => o.FormerPets)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<PreviousOwner> PreviousOwners { get; set; }
    }
}
