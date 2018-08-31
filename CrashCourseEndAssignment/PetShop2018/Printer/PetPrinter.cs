using PetShop2018.Core.ApplicationService;
using PetShop2018.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2018
{
    public class PetPrinter : IPrinter
    {
        PrinterFunctions printerFunctions = new PrinterFunctions();
        readonly IPetService _petService;

        public PetPrinter(IPetService petService)
        {
            _petService = petService;
        }

        public void InitiateMainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Select your option from the below |\n" +
                "|_______________________________|\n" +
                "Press 1 to: Create a new pet.\n" +
                "Press 2 to: List all pets.\n" +
                "Press 3 to: Update a pet.\n" +
                "Press 4 to: Delete a pet.\n" +
                "Press 5 to: Mark pet as sold.\n" +
                "Press 6 to Exit.");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int verifiedInput))
            {
                switch (verifiedInput)
                {
                    case 1:
                        Console.Clear();
                        InitiateCreatePetMenu();
                        break;
                    case 2:
                        Console.Clear();
                        InitiateListAllPetsMenu();
                        break;
                    case 3:
                        Console.Clear();
                        InitiateUpdatePetMenu();
                        break;
                    case 4:
                        Console.Clear();
                        InitiateDeletePetMenu();
                        break;
                    case 5:
                        Console.Clear();
                        InitiatePetSoldMenu();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid number, try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("You input must be a numerical.");
            }
            Console.ReadLine();
            InitiateMainMenu();
        }

        public void InitiateCreatePetMenu()
        {
            Console.WriteLine(
                "| Creating a pet |\n" +
                "|________________|\n");
            var pet = _petService.MakeTempPetItem();
            pet.Sold = false;
            pet.Name = printerFunctions.GetStringFromQuestion("- Enter name of pet:");
            pet.Color = printerFunctions.GetStringFromQuestion("\n- Enter primary color of pet:");
            pet.PreviousOwner = printerFunctions.GetStringFromQuestion("\n- Enter name of previous owner:");
            pet.AnimalCategory = printerFunctions.GetStringFromQuestion("\n- Enter a pet category:");
            pet.Price = printerFunctions.GetDoubleFromQuestion("\n- Enter a price for the pet:");
            pet.BirthDate = printerFunctions.GetDateFromQuestion("\n- Enter pets birthday (mm/dd/yy hh:mm:ss) :");

            _petService.CreatePet(pet);
        }

        public void InitiateListAllPetsMenu()
        {
            Console.WriteLine(
                "| Listing all pets |\n" +
                "|__________________|\n");
            var pets = _petService.GetPets();
            printerFunctions.PrintPet(pets);
            //listing by a specific order
            int input = printerFunctions.GetIntFromQuestion(
                "- Press 1: To sort list by price.\n" +
                "- Press 2: To sort by category.\n");
            switch (input)
            {
                case 1:
                    InitiateListByLowestPriceMenu();
                    break;
                case 2:
                    InitiateGetListByCategory();
                    break;
                default:
                    break;
            }

        }

        public void InitiateListByLowestPriceMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Ordering list by price |\n" +
                "|________________________|\n");
            var petsByPrice = _petService.GetPetsByLowestPrice();
            printerFunctions.PrintPet(petsByPrice);
            
            string input = printerFunctions.GetStringFromQuestion("- Write minimize to shorten the list");
            if(input.ToUpper() == "MINIMIZE")
            {
                Console.Clear();
                Console.WriteLine(
                "| Ordering list by price |\n" +
                "|________________________|\n");
                var cheapestPetsByPrice = _petService.GetPetsByLowestPrice(5);
                printerFunctions.PrintPet(cheapestPetsByPrice);
            }
        }

        public void InitiateGetListByCategory()
        {
            string categoryToFilter = printerFunctions.GetStringFromQuestion("- Enter a valid category:");
            var filteredCategory = _petService.GetPetsByCategory(categoryToFilter);
            Console.Clear();
            Console.WriteLine(
                "| Pets filtered by category |\n" +
                "|___________________________|\n");
            printerFunctions.PrintPet(filteredCategory);
            if (filteredCategory.Count == 0)
            {
                Console.WriteLine("No categories were found by the name {0}.", categoryToFilter);
            }
        }

        public void InitiateUpdatePetMenu()
        {
            Console.WriteLine(
                "| Updating a selected pet |\n" +
                "|_________________________|\n");
            int input = printerFunctions.GetIntFromQuestion("- Enter an id to select a pet:");
            if (input != 0)
            {
                var pet = _petService.GetPet(input);
                if (pet != null)
                {
                    bool stillUpdating = true;
                    while (stillUpdating)
                    {
                        Console.Clear();
                        Console.WriteLine(
                        "| Your selected pet |\n" +
                        "|___________________|\n");
                        printerFunctions.PrintPet(pet);
                        string variableToChange = printerFunctions.GetStringFromQuestion(
                            "- Enter the variable name, you wish to change\n" +
                            "or press exit, to exit.\n");
                        
                        switch (variableToChange.ToUpper())
                        {
                            case "EXIT":
                                stillUpdating = false;
                                break;
                            case "NAME":
                                pet.Name = printerFunctions.GetStringFromQuestion("- Enter new name:");
                                break;
                            case "COLOR":
                                pet.Color = printerFunctions.GetStringFromQuestion("- Enter new color:");
                                break;
                            case "PREVIOUS OWNER":
                            case "PREVIOUS":
                            case "OWNER":
                                pet.PreviousOwner = printerFunctions.GetStringFromQuestion("- Enter new previous owner:");
                                break;
                            case "CATEGORY":
                                pet.AnimalCategory = printerFunctions.GetStringFromQuestion("- Enter new category:");
                                break;
                            case "PRICE":
                                pet.Price = printerFunctions.GetIntFromQuestion("- Enter new price tag:");
                                break;
                            case "BIRTHDAY":
                                pet.BirthDate = printerFunctions.GetDateFromQuestion("- Enter new birthday (mm/dd/yy hh:mm:ss)");
                                break;
                            default:
                                Console.WriteLine("Your input was not a recognized variable of pet.");
                                Console.ReadLine();
                                break;
                        }

                    }

                }
                else
                {
                    Console.WriteLine("No pet was found with selected id.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        public void InitiateDeletePetMenu()
        {
            Console.WriteLine(
                "| Deleting selected pet |\n" +
                "|_______________________|");
            int input = printerFunctions.GetIntFromQuestion("- Enter an id to select a pet:");
            if (input != 0)
            {
                var deletedPet = _petService.DeletePet(input);
                if (deletedPet != null)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "| Pet has been successfully deleted |\n" +
                        "|___________________________________|");
                    printerFunctions.PrintPet(deletedPet);
                }
                else
                {
                    Console.WriteLine("No pet was found with selected id.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        public void InitiatePetSoldMenu()
        {
            Console.WriteLine(
                "| Mark selected pet as sold |\n" +
                "|___________________________|\n");
            int input = printerFunctions.GetIntFromQuestion("- Enter an id to select a pet:");
            if (input != 0)
            {
                var pet = _petService.GetPet(input);
                if (pet != null)
                {
                    pet.Sold = true;
                    pet.SoldDate = DateTime.Now.ToLocalTime();

                    Console.Clear();
                    Console.WriteLine(
                        "| Selected pet has been marked as sold |\n" +
                        "|______________________________________|\n");
                    printerFunctions.PrintPet(pet);
                }
                else
                {
                    Console.WriteLine("No pet was found with selected id.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
