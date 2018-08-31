using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Core.DomainService
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        Pet GetPet(int id);
        IEnumerable<Pet> GetPets();

        Pet UpdatePet(Pet petChanges);

        Pet DeletePet(int id);
    }
}
