using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Core.ApplicationService
{
    public interface IPetService
    {
        Pet MakeTempPetItem();

        Pet CreatePet(Pet pet);

        Pet GetPet(int id);
        List<Pet> GetPets();
        List<Pet> GetPetsByLowestPrice();
        List<Pet> GetPetsByLowestPrice(int numberOfPets);
        List<Pet> GetPetsByCategory(string category);

        Pet UpdatePet(Pet petChanges);

        Pet DeletePet(int id);
    }
}
