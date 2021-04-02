using BadgesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesProgram
{
    public class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Have a good day!");
                        Console.ReadKey();
                        break;
                    default:
                        break;

                }
            }
        }

        private void EditBadge()
        {
            Console.Clear();

            Console.WriteLine("What badge ID do you want to edit? Be sure to choose an already existing badge!");
            int userInputNewBadge = int.Parse(Console.ReadLine());

            BadgeContent newBadgeContent = new BadgeContent();

            Console.WriteLine("Please enter the ALL of the doors this key will have access to divided by a comma and a space. (1, 10, 100) ");
            string newBadgeDoors = Console.ReadLine();
            newBadgeContent.ListOfDoors = newBadgeDoors;

            _badgeRepo.EditBadge(userInputNewBadge, newBadgeContent);

        }

        private void ShowAllBadges()
        {
            Console.Clear();
            foreach (var badge in _badgeRepo.GetBadge())
            {
                Console.WriteLine($"Badge ID: {badge.Value.BadgeID}\n" +
                    $"Door Access: {badge.Value.ListOfDoors}\n" +
                    $"");
            }
            Console.ReadKey();
        }

        private void AddBadge()
        {
            Console.Clear();

            BadgeContent badge = new BadgeContent();

            Console.WriteLine("What is the number on the new badge?");
            int userInputID = int.Parse(Console.ReadLine());
            badge.BadgeID = userInputID;

            Console.WriteLine("List all the doors it needs access to divided by a comma and a space. (1, 10, 100)");
            string userInputDoors = Console.ReadLine();
            badge.ListOfDoors = userInputDoors;
            _badgeRepo.AddBadgeToDataBase(badge);

        }

        private void Seed()
        {
            BadgeContent firstBadge = new BadgeContent(1, "A1, A4, A10");
            BadgeContent SecondBadge = new BadgeContent(2, "A1, A4, A15");
            BadgeContent thirdBadge = new BadgeContent(3, "A1, A4, A19");

            _badgeRepo.AddBadgeToDataBase(firstBadge);
            _badgeRepo.AddBadgeToDataBase(SecondBadge);
            _badgeRepo.AddBadgeToDataBase(thirdBadge);

        }
    }
}
