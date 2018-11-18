using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShop2018Context ctx)
        {
            //For total reset of db, on restart.
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();

                /*//PRE-DB Owners
                var owner1 = ctx.PreviousOwners.Add(new PreviousOwner()
                {
                    Name = "Jørgen",
                    PhoneNumber = 85696326
                }).Entity;
                var owner2 = ctx.PreviousOwners.Add(new PreviousOwner()
                {
                    Name = "Hooman, not dog",
                    PhoneNumber = 11111111
                }).Entity;

                //PRE-DB Pets
                ctx.Pets.Add(new Pet()
                {
                    Color = "Black/White stribed",
                    Name = "John",
                    Price = 1500,
                    AnimalCategory = "Dog",
                    PreviousOwner = owner2
                });

                ctx.Pets.Add(new Pet()
                {
                    Color = "Black",
                    Name = "Flemming",
                    Price = 150,
                    AnimalCategory = "Cat",
                    PreviousOwner = owner1
                });

                ctx.SaveChanges();*/
            
        }
    }
}
