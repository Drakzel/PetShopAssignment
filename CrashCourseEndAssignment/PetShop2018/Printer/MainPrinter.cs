using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018.Printer
{
    public class MainPrinter : IPrinter
    {
        public void InitiateMainMenu()
        {
            Console.WriteLine(
                "| Make a selection from below |\n" +
                "|_____________________________|\n" +
                "Press:\n" +
                "1: For customers.\n" +
                "2: For pets.\n");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int verifiedNumber))
            {
                switch (verifiedNumber)
                {
                    default:
                        Console.WriteLine("Invalid number.");
                        break;
                }
            }
        }
    }
}
