using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop2018.Core.DomainService;
using PetShop2018.Core.Entities;

namespace PetShop2018.Core.ApplicationService.Services
{
    public class PreviousOwnerService : IPreviousOwnerService
    {
        private readonly IPreviousOwnerRepository _previousOwnerRepository;

        public PreviousOwnerService(IPreviousOwnerRepository previousOwnerRepository)
        {
            _previousOwnerRepository = previousOwnerRepository;
        }

        public PreviousOwner CreatePreviousOwner(PreviousOwner preOwner)
        {
            return _previousOwnerRepository.CreatePreviousOwner(preOwner);
        }

        public PreviousOwner DeletePreviousOwner(int id)
        {
            return _previousOwnerRepository.DeleteCustomer(id);
        }

        public PreviousOwner GetPreviousOwner(int id)
        {
            return _previousOwnerRepository.GetPreviousOwner(id);
        }

        public List<PreviousOwner> GetPreviousOwners()
        {
            return _previousOwnerRepository.GetPreviousOwners().ToList();
        }

        public PreviousOwner UpdatePreviousOwner(PreviousOwner preOwnerChanges)
        {
            return _previousOwnerRepository.UpdateCustomer(preOwnerChanges);
        }
    }
}
