using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Core.Entities
{
    public class PreviousOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public List<Pet> FormerPets { get; set; }
    }
}
