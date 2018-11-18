using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Core.DomainService
{
    public interface IPreviousOwnerRepository
    {
        PreviousOwner CreatePreviousOwner(PreviousOwner preOwner);

        PreviousOwner GetPreviousOwner(int id);
        IEnumerable<PreviousOwner> GetPreviousOwners();

        PreviousOwner UpdatePreviousOwner(PreviousOwner preOwnerChanges);

        PreviousOwner DeletePreviousOwner(int id);
    }
}
