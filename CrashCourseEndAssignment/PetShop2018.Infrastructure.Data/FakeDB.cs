using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Infrastructure.Data
{
    public class FakeDB
    {
        public static int PreOwnerId = 1;
        public static List<PreviousOwner> PreOwners = new List<PreviousOwner>();

        public static int PetId = 1;
        public static List<Pet> Pets = new List<Pet>();
        
        public static void InitData()
        {
            var preOwner1 = new PreviousOwner()
            {
                Id = PreOwnerId++,
                Name = "Bob",
                PhoneNumber = 54263598
            };
            PreOwners.Add(preOwner1);

            var pet1 = new Pet()
            {
                Id = PetId++,
                AnimalCategory = "Dog",
                Color = "Blå",
                Name = "IkkeBob",
                Price = 500,
                Sold = true,
                BirthDate = new DateTime(1999, 05, 26),
                SoldDate = new DateTime(2003, 02, 07),
                PreviousOwner = preOwner1

            };
            Pets.Add(pet1);

            var preOwner2 = new PreviousOwner()
            {
                Id = PreOwnerId++,
                Name = "Jamal",
                PhoneNumber = 65329647
            };
            PreOwners.Add(preOwner2);

            var pet2 = new Pet()
            {
                Id = PetId++,
                AnimalCategory = "Cat",
                Color = "Black",
                Name = "Flamingo",
                Price = 596,
                Sold = false,
                BirthDate = new DateTime(2002, 11, 09),
                PreviousOwner = preOwner2

            };
            Pets.Add(pet2);
        }
    }
}
