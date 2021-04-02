using CafeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsoleApp
{
    public class ProgramUI
    {
        private readonly CafeContentRepo _contentRepo = new CafeContentRepo();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool contunueToRun = true;
            while (contunueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you would like to select:\n" +
                    "1: Show all Menu Items \n" +
                    "2: Find Meal by name\n" +
                    "3: Add new Item\n" +
                    "4: Remove Existing Item\n" +
                    "5: Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllItems();
                        break;
                    case "2":
                        ShowItemByName();
                        break;
                    case "3":
                        CreateNewItem();
                        break;
                    case "4":
                        DeleteItem();
                        break;
                    case "5":
                        contunueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 5\n" +
                           "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
        }

        private void CreateNewItem()
        {
            Console.Clear();
            CafeContent item = new CafeContent();
            Console.WriteLine("Want to add a brand new item?? Sweet!");

            Console.WriteLine("Please enter the name of the item!");
            item.Name = Console.ReadLine();

            Console.WriteLine("Please enter a description of the new item! ");
            item.Description = Console.ReadLine();

            Console.WriteLine("Please enter a list of ingredientes!");
            item.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter the price of the new item!");
            item.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the the meal number for the new item!");
            item.MealNumber = int.Parse(Console.ReadLine());

            _contentRepo.AddItemToMenu(item);


        }
        private void ShowAllItems()
        {
            Console.Clear();
            List<CafeContent> listOfContent = _contentRepo.GetContent();
            foreach (CafeContent item in listOfContent)
            {
                DisplayContent(item);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowItemByName()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the item!");
            string name = Console.ReadLine();
            CafeContent item = _contentRepo.GetContentByName(name);
            if(item != null)
            {
                DisplayContent(item);
            }
            else
            {
                Console.WriteLine($"Invalid name. could night find {item}.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        private void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("Which item would you like to remove?");
            List<CafeContent> contentList = _contentRepo.GetContent();
            int count = 0;
            foreach(CafeContent item in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {item.Name}");
            }
            int targetContentID = int.Parse(Console.ReadLine());
            int targetIndex = targetContentID - 1;

            if(targetIndex >= 0 && targetIndex < contentList.Count)
            {
                CafeContent desiredContent = contentList[targetIndex];
                if (_contentRepo.DeleteMealFromMenu(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.Name} was successfully removed!");
                }
                else
                {
                    Console.WriteLine("I am sorry, I can not do that!");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        
        }
        private void DisplayContent(CafeContent item)
        {
            Console.WriteLine($"Name: {item.Name}\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.Ingredients}\n" +
                $"Price: {item.Price}\n" +
                $"Meal Number: {item.MealNumber}");
        }

        private void SeedContentList()
        {
            CafeContent doubleAngus = new CafeContent("Double Angus Thicc Burger", "Made with Angus Black Beef, your food will melt in your mouth!", "Bread, Beef, Cheese, Thiccness", 10.99d, 1);
            _contentRepo.AddItemToMenu(doubleAngus);
        }


    }
}
