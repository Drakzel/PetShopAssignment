using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018
{
    public class PrinterFunctions
    {
        public void PrintPet(Pet pet)
        {
            Console.WriteLine(
                "Id: {0}\n" +
                "Name: {1}\n" +
                "Color: {2}\n" +
                "Previous Owner: {3}\n" +
                "Category: {4}\n" +
                "Price: {5}\n" +
                "Birthday: {6}\n", pet.Id, pet.Name, pet.Color, 
                pet.PreviousOwner, pet.AnimalCategory, pet.Price, pet.BirthDate);
            if (pet.Sold) { Console.WriteLine("{0} was sold on: {1}\n", pet.Name, pet.SoldDate); }
        }

        public void PrintPet(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                PrintPet(pet);
            }
        }
        
        public string GetStringFromQuestion(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            return answer;
        }

        public double GetDoubleFromQuestion(string question)
        {
            string answer = GetStringFromQuestion(question);
            if (double.TryParse(answer, out double verifiedNumber))
            {
                return verifiedNumber;
            }
            return 0;
        }

        public int GetIntFromQuestion(string question)
        {
            string answer = GetStringFromQuestion(question);
            if (int.TryParse(answer, out int verifiedNumber))
            {
                return verifiedNumber;
            }
            return 0;
        }

        public DateTime GetDateFromQuestion(string question)
        {
            string answer = GetStringFromQuestion(question);
            if (DateTime.TryParse(answer, out DateTime verifiedNumber))
            {
                return verifiedNumber;
            }
            return DateTime.Now;
        }
    }
}
