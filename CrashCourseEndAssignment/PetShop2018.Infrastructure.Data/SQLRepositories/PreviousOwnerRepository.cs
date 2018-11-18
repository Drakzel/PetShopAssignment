using Microsoft.EntityFrameworkCore;
using PetShop2018.Core.DomainService;
using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop2018.Infrastructure.Data.SQLRepositories
{
    public class PreviousOwnerRepository : IPreviousOwnerRepository
    {
        private readonly PetShop2018Context _ctx;

        public PreviousOwnerRepository(PetShop2018Context ctx)
        {
            _ctx = ctx;
        }

        public PreviousOwner CreatePreviousOwner(PreviousOwner preOwner)
        {
            _ctx.Attach(preOwner).State = EntityState.Added;
            _ctx.SaveChanges();
            return preOwner;
        }

        public PreviousOwner DeletePreviousOwner(int id)
        {
            //Cascade delete
            //var petsToRemove = _ctx.Pets.Where(p => p.PreviousOwner.Id == id);
            //_ctx.RemoveRange(petsToRemove);

            var ownerRemoved = _ctx.Remove(new PreviousOwner { Id = id }).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public PreviousOwner GetPreviousOwner(int id)
        {
            return _ctx.PreviousOwners.FirstOrDefault(p => p.Id == id);

        }

        public IEnumerable<PreviousOwner> GetPreviousOwners()
        {
            return _ctx.PreviousOwners;
        }

        public PreviousOwner UpdatePreviousOwner(PreviousOwner preOwnerChanges)
        {
            _ctx.Attach(preOwnerChanges).State = EntityState.Modified;
            _ctx.Entry(preOwnerChanges).Reference(p => p.FormerPets).IsModified = true;
            _ctx.SaveChanges();
            return preOwnerChanges;
        }
    }
}
