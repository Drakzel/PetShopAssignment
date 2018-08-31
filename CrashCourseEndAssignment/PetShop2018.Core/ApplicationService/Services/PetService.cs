using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop2018.Core.DomainService;
using PetShop2018.Core.Entities;

namespace PetShop2018.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet MakeTempPetItem()
        {
            return new Pet();
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }

        public Pet GetPet(int id)
        {
            return _petRepository.GetPet(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepository.GetPets().ToList();
        }

        public List<Pet> GetPetsByLowestPrice()
        {
            var list = GetPets();
            var queryContinued = list.OrderBy(pet => pet.Price);
            return queryContinued.ToList();
        }

        public List<Pet> GetPetsByLowestPrice(int numberOfPets)
        {
            var list = GetPets();
            var queryContinued = list.OrderBy(pet => pet.Price);
            var finalQueryContinued = queryContinued.Take(numberOfPets);
            return finalQueryContinued.ToList();
        }

        public List<Pet> GetPetsByCategory(string category)
        {
            var list = GetPets().Where(pet => pet.AnimalCategory.Equals(category));
            return list.ToList();
        }

        public Pet UpdatePet(Pet petChanges)
        {
            return _petRepository.UpdatePet(petChanges);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
        }
    }
}
