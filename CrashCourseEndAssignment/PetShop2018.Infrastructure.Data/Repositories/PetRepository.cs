using PetShop2018.Core.DomainService;
using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            pet.Id = FakeDB.PetId++;
            FakeDB.Pets.Add(pet);

            return pet;
        }

        public Pet GetPet(int id)
        {
            foreach (var pet in FakeDB.Pets)
            {
                if (id == pet.Id)
                {
                    return pet;
                }
            }
            return null;
        }

        public IEnumerable<Pet> GetPets()
        {
            return FakeDB.Pets;
        }

        public Pet UpdatePet(Pet petChanges)
        {
            Pet newPet = GetPet(petChanges.Id);
            if (newPet != null)
            {
                newPet.Name = petChanges.Name;
                newPet.Color = petChanges.Color;
                newPet.AnimalCategory = petChanges.AnimalCategory;
                newPet.PreviousOwner = petChanges.PreviousOwner;
                newPet.Price = petChanges.Price;
                newPet.SoldDate = petChanges.SoldDate;
                newPet.BirthDate = petChanges.BirthDate;

                return newPet;
            }
            
            return null;
        }

        public Pet DeletePet(int id)
        {
            Pet petToDelete = GetPet(id);
            if (petToDelete != null)
            {
                FakeDB.Pets.Remove(petToDelete);
                return petToDelete;
            }

            return null;
        }

        public IEnumerable<Pet> GetPets(Filter filter = null)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
