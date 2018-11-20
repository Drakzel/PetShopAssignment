using Microsoft.EntityFrameworkCore;
using PetShop2018.Core.DomainService;
using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop2018.Infrastructure.Data.SQLRepositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShop2018Context _ctx;

        public PetRepository(PetShop2018Context ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }

        public Pet CreatePet(Pet pet)
        {
            /*if (pet.PreviousOwner != null &&
                _ctx.ChangeTracker.Entries<PreviousOwner>()
                .FirstOrDefault(pe => pe.Entity.Id == pet.PreviousOwner.Id) == null)
            {
                _ctx.Attach(pet.PreviousOwner);
            }
            var petCreated = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return petCreated;*/

            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var petRemoved = _ctx.Remove(new Pet { Id = id }).Entity;
            _ctx.SaveChanges();
            return petRemoved;
        }

        public Pet GetPet(int id)
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pet> GetPets(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Pets;
            }
            return _ctx.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);
        }

        public Pet UpdatePet(Pet petChanges)
        {
            /*if (petChanges.PreviousOwner != null &&
                _ctx.ChangeTracker.Entries<PreviousOwner>()
                .FirstOrDefault(pe => pe.Entity.Id == petChanges.PreviousOwner.Id) == null)
            {
                _ctx.Attach(petChanges.PreviousOwner);
            }
            else
            {
                _ctx.Entry(petChanges).Reference(p => p.PreviousOwner).IsModified = true;
            }

            var newPet = _ctx.Update(petChanges).Entity;
            _ctx.SaveChanges();
            return newPet;*/

            _ctx.Attach(petChanges).State = EntityState.Modified;
            _ctx.Entry(petChanges).Reference(p => p.PreviousOwner).IsModified = true;
            _ctx.SaveChanges();
            return petChanges;
        }
    }
}
