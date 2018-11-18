using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Core.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public PreviousOwner PreviousOwner { get; set; }
        public string AnimalCategory { get; set; }
        public double Price { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Sold { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
