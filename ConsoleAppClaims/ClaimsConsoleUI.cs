using ClaimsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClaims
{
    public class ClaimsConsoleUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you would like to select:\n" +
                    "1: See all claims \n" +
                    "2: Take care of next claim\n" +
                    "3: Enter a new claim\n" +
                    "4: Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;


                }


            }
        }
        private void NextClaim()
        {
            Console.Clear();
            Console.WriteLine("Do you want Start on a case now? (Y/N}");
            string dealWithClaim = Console.ReadLine();
            dealWithClaim = dealWithClaim.ToUpper();

            if (dealWithClaim == "Y")
            {
                Console.WriteLine("Which case would you like to start working on?");
                List<ClaimsContent> claimsList = _claimsRepo.GetContent();
                int count = 0;
                foreach (ClaimsContent claim in claimsList)
                {
                    count++;
                    Console.WriteLine($"{count}.\n" +
                        $"ID: {claim.ClaimID}\n" +
                        $"Type: {claim.ClaimType}\n" +
                        $"Description: {claim.Description}\n" +
                        $"Date of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +
                        $"Date of Claim: {claim.DateOfClaim.ToShortDateString()}\n" +
                        $"Is the claim valid: {claim.IsValid}\n" +
                        $"\n" +
                        $"\n" +
                        $"");
                        
                }
                int targetClaimID = int.Parse(Console.ReadLine());
                int targetIndex = targetClaimID - 1;
                if(targetIndex >= 0 && targetIndex < claimsList.Count)
                {
                    ClaimsContent desiredContent = claimsList[targetIndex];
                    if (_claimsRepo.DeleteClaim(desiredContent))
                    {
                        Console.WriteLine($"You have chosen to work on case number {desiredContent.ClaimID}. It has been removed from the queue.");
                    }
                    else
                    {

                        Console.WriteLine("I'm sorry, I can't do that.");
                    }
                }
                else
                {
                    Console.WriteLine("No content has that ID.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
            else
            {
                return;
            }
            
        }
        private void CreateNewClaim()
        {

            ClaimsContent claim = new ClaimsContent();
            Console.Clear();
            Console.WriteLine("Please enter a Claim ID for the new claim");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Select claim type. Be sure to use number 1-3.\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3 Theft");
            string claimType = Console.ReadLine();

            switch (claimType)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 3\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            DateTime incidentDate;
            DateTime claimDate;

            Console.WriteLine("Please enter a description of the incident");
            claim.Description = Console.ReadLine();

            Console.WriteLine("What is the claim ammount?");
            claim.ClaimAmmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Date of incident? YYYY/MM/DD ");
            DateTime.TryParse(Console.ReadLine(), out incidentDate);
            claim.DateOfIncident = incidentDate;

            Console.WriteLine("Date of Claim? YYYY/MM/DD");
            DateTime.TryParse(Console.ReadLine(), out claimDate);
            claim.DateOfClaim = claimDate;

            _claimsRepo.AddClaimToDirectory(claim);
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            List<ClaimsContent> listOfClaims = _claimsRepo.GetContent();
            foreach (ClaimsContent claim in listOfClaims)
            {
                DisplayContent(claim);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        private void DisplayContent(ClaimsContent claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                   $"Claim Type: {claim.ClaimType}\n" +
                   $"Description: {claim.Description}\n" +
                   $"Claim Ammount: ${claim.ClaimAmmount}\n" +
                   $"Date Of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +
                   $"DateOfClaim: {claim.DateOfClaim.ToShortDateString()}\n" +
                   $"Is Valid: {claim.IsValid}\n" +
                   $"\n" +
                   $"");


        }
        private void SeedContentList()

        {


            DateTime incidentOne = new DateTime(2017, 04, 25);
            DateTime claimOne = new DateTime(2017, 04, 27);
            ClaimsContent firstClaim = new ClaimsContent(1, ClaimType.Car, "Car accident on 465", 400d, incidentOne, claimOne);
            ClaimsContent secondClaim = new ClaimsContent(2, ClaimType.Car, "Car accident on 465", 400d, incidentOne, claimOne);
            ClaimsContent thirdClaim = new ClaimsContent(3, ClaimType.Car, "Car accident on 465", 400d, incidentOne, claimOne);
            ClaimsContent forthClaim = new ClaimsContent(4, ClaimType.Car, "Car accident on 465", 400d, incidentOne, claimOne);
            ClaimsContent fifthClaim = new ClaimsContent(5, ClaimType.Car, "Car accident on 465", 400d, incidentOne, claimOne);

            _claimsRepo.AddClaimToDirectory(firstClaim);
            _claimsRepo.AddClaimToDirectory(secondClaim);
            _claimsRepo.AddClaimToDirectory(thirdClaim);
            _claimsRepo.AddClaimToDirectory(forthClaim);
            _claimsRepo.AddClaimToDirectory(fifthClaim);
        }
    }
}
