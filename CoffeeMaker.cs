using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighRiskCafe
{
    internal class CoffeeMaker
    {

        Coffee coffe = new();
        List<String> coffeeTypesList = new();
        bool success;

        public void MakeCoffee()
        {
          bool isWantingCoffee =  AskForCoffee();
            if (isWantingCoffee)
            {
                AddCoffeeTypesToList();
                DisplayCoffeeTypes();
               string coffeeType = AskUserWhichCoffeeItWants();
               bool validatedCoffeeType = ValidateCoffeeType(coffeeType);
                if (validatedCoffeeType)
                {                    
                        success = PutCoffeeInMachine();
                        if (success)
                        {
                            success = PutWaterInMachine();
                            if (success)
                            {
                                PlaceCupInMachine();
                                if (success)
                                {
                                    StartMachine();
                                    if (success)
                                    {
                                        ServeCoffeeToGuest();
                                        
                                    }
                                    else
                                    {
                                        DisplayOrder();
                                    }
                                }
                                else
                                {
                                    DisplayOrder();
                                }
                            }
                            else
                            {
                                DisplayOrder();
                            }
                        }                        
                            else
                            {
                                DisplayOrder();
                            }                     
                        
                  
                }
                else
                {
                    DisplayOrder();
                }
                
            }
            else
            {
                Console.WriteLine("No coffee for you then, thanks anyways!");
                Environment.Exit(0);
            }

        }

        private void DisplayOrder()
        {
            Console.WriteLine();
            string errorMessageForUser = "Something went wrong.";
            string analyze = "Analyzing...";
            foreach (var character in errorMessageForUser)
            {
                Console.Write(character);
                Thread.Sleep(30);
            }
            Thread.Sleep(1000);
            Console.WriteLine();
            foreach (var characters in analyze)
            {
                Console.Write(characters);
                Thread.Sleep(30);
            }
            Thread.Sleep(2000);
            Console.WriteLine();
            
            Console.WriteLine($"{coffe.FailedStep}");
        }

        private bool CalculateSuccess()
        {
            Random random = new();
            int randomGenerated = random.Next(1, 6);
            if (randomGenerated < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
            
            
        }

        private bool ValidateCoffeeType(string coffeType)
        {
            if (coffeeTypesList.Contains(coffeType))
            {
                return true;
            }
            else
            {
                Console.WriteLine("No coffee type matches your request!");
                return false;
            }
        }

        private string AskUserWhichCoffeeItWants()
        {
            Console.WriteLine();
            string askUserWhatCoffee = "Which coffee type do you want?";
            string reply = "Reply: ";
            foreach(var c in askUserWhatCoffee)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            foreach (var ch in reply)
            {
                Console.Write(ch);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            string coffeetype = Console.ReadLine().ToUpper();
            coffe.CoffeeType = coffeetype;
            Console.Clear();
            return coffeetype;
        }

        private void DisplayCoffeeTypes()
        {
            Console.WriteLine("Here´s what we´re offering: ");
            Thread.Sleep(1000);
            foreach (string coffee in coffeeTypesList)
            {
                Console.WriteLine(coffee.ToUpper());
                Thread.Sleep(500);
            }
        }

        private void AddCoffeeTypesToList()
        {
            coffeeTypesList.Add("ESPRESSO");
            coffeeTypesList.Add("AMERICANO");
            coffeeTypesList.Add("MACCHIATO");
            coffeeTypesList.Add("CORTADO");
            coffeeTypesList.Add("CAPPUCHINO");
            coffeeTypesList.Add("MOCHA");
        }

        private bool AskForCoffee()
        {
            string doUWantCoffee = "Do you want coffee? Yes/No?";
            foreach (var character in doUWantCoffee)
            {
                Console.Write(character);
                Thread.Sleep(30);
            }
            Console.WriteLine();
            
            string customerAnswer = Console.ReadLine().ToUpper();
            if (customerAnswer == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool PutCoffeeInMachine()
        {
            string analyze = "Analyzing...";
            foreach(var character in analyze)
            {
                Console.Write(character);
                Thread.Sleep(50);
            }
            Thread.Sleep(2000);
            Console.WriteLine();
            success = CalculateSuccess();
            string messageForUser = "Putting coffee in machine...";
            if (success == true)
            {
                foreach (var character in messageForUser)
                {
                    Console.Write(character);
                    Thread.Sleep(50);
                }
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                coffe.IsDone = false;
                coffe.FailedStep = "Cant put coffee in to the machine";
                return false;
            }
            
        }
        private bool PutWaterInMachine()
        {
            Console.WriteLine();
            string messageForUser = "Pouring water in to the machine...";
            success = CalculateSuccess();
            if (success == true)
            {
                foreach (var characther in messageForUser)
                {
                    Console.Write(characther);
                    Thread.Sleep(50);
                }
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                coffe.IsDone = false;
                coffe.FailedStep = "Cant put water in the machine";
                return false;
            }
        }
        private bool PlaceCupInMachine()
        {
            Console.WriteLine();
            string messageForUser = "Placing cup in machine...";
            success = CalculateSuccess();
            if (success == true)
            {
                foreach(var characther in messageForUser)
                {
                    Console.Write(characther);
                    Thread.Sleep(50);
                }
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                coffe.IsDone = false;
                coffe.FailedStep = "Cant place cup in the machine";
                return false;
            }
        }
        private bool StartMachine()
        {
            Console.WriteLine();
            string messageForUser = "Machine is starting...";
            success = CalculateSuccess();
            if (success == true)
            {
                foreach(var characther in messageForUser)
                {
                    Console.Write(characther);
                    Thread.Sleep(50);
                }
                Thread.Sleep(2000);
                return true;
            }
            else
            {
                coffe.IsDone = false;
                coffe.FailedStep = "Machine couldn´t start";
                return false;
            }
           
        }
        private void ServeCoffeeToGuest()
        {
            coffe.IsDone = true;
           
            string messageForUser = "Here´s your coffee a nice warm" + " " + coffe.CoffeeType + " " + "enjoy!";
            Console.WriteLine();
            foreach (var character in messageForUser)
            {
                Console.Write(character);
                Thread.Sleep(50);
            }
            
        }
    }
       
}
