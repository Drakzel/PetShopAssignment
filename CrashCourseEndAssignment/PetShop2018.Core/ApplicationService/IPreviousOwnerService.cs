using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Core.ApplicationService
{
    public interface IPreviousOwnerService
    {
        PreviousOwner CreatePreviousOwner (PreviousOwner preOwner);

        PreviousOwner GetPreviousOwner(int id);
        PreviousOwner GetPreviousOwnerIncludePets(int id);
        List<PreviousOwner> GetPreviousOwners();

        PreviousOwner UpdatePreviousOwner(PreviousOwner preOwnerChanges);

        PreviousOwner DeletePreviousOwner(int id);
    }
}
