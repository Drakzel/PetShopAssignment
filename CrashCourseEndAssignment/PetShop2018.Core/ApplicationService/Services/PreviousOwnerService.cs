using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop2018.Core.DomainService;
using PetShop2018.Core.Entities;

namespace PetShop2018.Core.ApplicationService.Services
{
    public class PreviousOwnerService : IPreviousOwnerService
    {
        private readonly IPreviousOwnerRepository _previousOwnerRepository;
        private readonly IPetRepository _petRepository;

        public PreviousOwnerService(IPreviousOwnerRepository previousOwnerRepository,
            IPetRepository petRepository)
        {
            _previousOwnerRepository = previousOwnerRepository;
            _petRepository = petRepository;
        }

        public PreviousOwner CreatePreviousOwner(PreviousOwner preOwner)
        {
            if (preOwner.FormerPets == null)
                throw new InvalidDataException("To create previous owner you need a pet");
            
            return _previousOwnerRepository.CreatePreviousOwner(preOwner);
        }

        public PreviousOwner DeletePreviousOwner(int id)
        {
            return _previousOwnerRepository.DeletePreviousOwner(id);
        }

        public PreviousOwner GetPreviousOwner(int id)
        {
            return _previousOwnerRepository.GetPreviousOwner(id);
        }

        public PreviousOwner GetPreviousOwnerIncludePets(int id)
        {
            var previousOwner = _previousOwnerRepository.GetPreviousOwner(id);
            previousOwner.FormerPets = _petRepository.GetPets()
                .Where(pet => 
                    pet.PreviousOwner != null &&
                    pet.PreviousOwner.Id == previousOwner.Id)
                .ToList();
            return previousOwner;
        }

        public List<PreviousOwner> GetPreviousOwners()
        {
            return _previousOwnerRepository.GetPreviousOwners().ToList();
        }

        public PreviousOwner UpdatePreviousOwner(PreviousOwner preOwnerChanges)
        {
            return _previousOwnerRepository.UpdatePreviousOwner(preOwnerChanges);
        }
    }
}
