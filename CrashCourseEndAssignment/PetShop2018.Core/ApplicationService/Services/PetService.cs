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
        readonly IPreviousOwnerRepository _previousOwnerRepository;

        public PetService(IPetRepository petRepository,
            IPreviousOwnerRepository previousOwnerRepository)
        {
            _petRepository = petRepository;
            _previousOwnerRepository = previousOwnerRepository;
        }

        public Pet MakeTempPetItem()
        {
            return new Pet();
        }

        public Pet CreatePet(Pet pet)
        {
            var createdPet = _petRepository.CreatePet(pet);
            createdPet.PreviousOwner = _previousOwnerRepository.GetPreviousOwner(createdPet.PreviousOwner.Id);

            return createdPet;
        }

        public Pet GetPet(int id)
        {
            return _petRepository.GetPet(id);
        }

        public List<Pet> GetPets()
        {
            var list = _petRepository.GetPets().ToList();
            /*foreach (var pet in list)
            {
                pet.PreviousOwner =
                    _previousOwnerRepository.GetPreviousOwner(pet.PreviousOwner.Id);
            }*/
            return list;
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
