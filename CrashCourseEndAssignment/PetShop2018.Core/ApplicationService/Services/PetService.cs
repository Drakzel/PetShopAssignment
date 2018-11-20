using System;
using System.Collections.Generic;
using System.IO;
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
            //if (variable of pet, is null, then throw exception.
            return _petRepository.CreatePet(pet);
            
        }

        public Pet GetPet(int id)
        {
            var pet = _petRepository.GetPet(id);
            
            return pet;
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

        public List<Pet> GetFilteredPets(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("Current page and items pr page, must be atleast 0.");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _petRepository.Count())
            {
                throw new InvalidDataException("Index out of bounds, current page is too high.");
            }
            return _petRepository.GetPets(filter).ToList();
        }

        public Pet UpdatePet(Pet petChanges)
        {
            return _petRepository.UpdatePet(petChanges);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
        }

        public Pet GetPetWithOwner(int id)
        {
            var pet = _petRepository.GetPet(id);
            pet.PreviousOwner = _previousOwnerRepository.GetPreviousOwner(pet.PreviousOwner.Id);
            //Meaning our pet must have an existing id of the owner
            return pet;
        }
    }
}
