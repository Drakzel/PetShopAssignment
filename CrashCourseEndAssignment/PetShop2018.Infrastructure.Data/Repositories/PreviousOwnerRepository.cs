using PetShop2018.Core.DomainService;
using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Infrastructure.Data.Repositories
{
    public class PreviousOwnerRepository : IPreviousOwnerRepository
    {
        public PreviousOwner CreatePreviousOwner(PreviousOwner preOwner)
        {
            preOwner.Id = FakeDB.PreOwnerId++;
            FakeDB.PreOwners.Add(preOwner);

            return preOwner;
        }

        public PreviousOwner DeleteCustomer(int id)
        {
            var preOwner = GetPreviousOwner(id);
            if (preOwner != null)
            {
                FakeDB.PreOwners.Remove(preOwner);

                return preOwner;
            }
            return null;
        }

        public PreviousOwner GetPreviousOwner(int id)
        {
            foreach (var owner in FakeDB.PreOwners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public IEnumerable<PreviousOwner> GetPreviousOwners()
        {
            return FakeDB.PreOwners;
        }

        public PreviousOwner UpdatePreviousOwner(PreviousOwner preOwnerChanges)
        {
            var newPreOwner = GetPreviousOwner(preOwnerChanges.Id);
            if (newPreOwner != null)
            {
                newPreOwner.Name = preOwnerChanges.Name;
                newPreOwner.PhoneNumber = preOwnerChanges.PhoneNumber;

                return newPreOwner;
            }
            return null;
        }
    }
}
