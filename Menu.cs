using System;
using System.Linq;

namespace CarParkApp
{
    public static class Menu
    {
        public static void Presentation()
        {
            Console.WriteLine("Car Park Application by Francesco Morelli");
            Console.WriteLine("Select from the following options:");
            Console.WriteLine("1)Insert Car\n2)Remove Car\n3)List all cars\n4)Find Car by guest name\nX)To exit the application");
            var userInput = Console.ReadLine().ToUpper();
            Selection(userInput);
        }

        public static void Selection(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    InsertCarDetails();
                    break;

                case "2":
                    RemoveCarDetails();
                    break;

                case "3":
                    ListAllCarsDetails();
                    break;
                case "4":
                    FindGuestCarDetails();
                    break;
                case "X":
                    ExitProgram();
                    break;
                default:
                    Console.Clear();
                    Presentation();
                    break;
            }
        }

        public static void InsertCarDetails()
        {
            
            Console.WriteLine("Enter customer name: ");
            var customerName = Console.ReadLine();

            Console.WriteLine("Enter customer phone number: ");
            string phoneNumber = Console.ReadLine();

            bool containsLetters = phoneNumber.Any(char.IsLetter);

            if (containsLetters == true)
            {
                Console.WriteLine($"The phone number entered: {phoneNumber}, contains letters, retry.");
                Presentation();
                return;
            }

            Console.WriteLine("Enter the customer's car licence plate number");
            var licencePlate = Console.ReadLine();

            CarPark.InsertCar(new Customer(customerName, phoneNumber, licencePlate));
        }

        public static void RemoveCarDetails()
        {
            Console.Clear();
            Console.WriteLine("Enter the licence plate of the car you would like to remove");
            var licencePlate = Console.ReadLine();

            if(licencePlate == null || licencePlate == "")
            {
                RemoveCarDetails();
            }
            CarPark.RemoveCar(licencePlate);
        }

        public static void FindGuestCarDetails()
        {
            Console.Clear();
            Console.WriteLine("Enter the guest name to find its car:");
            var guestName = Console.ReadLine();

            if (guestName == null || guestName == "")
                FindGuestCarDetails();

            CarPark.FindGuestCar(guestName);
        }

        public static void ListAllCarsDetails()
        {
            Console.Clear();
            CarPark.ListAllCars();
        }

        public static void ExitProgram()
        {
            Console.WriteLine("Are you sure? [Y/N]");
            var userInput = Console.ReadLine().ToUpper();
            if (userInput == "Y" || userInput == "YES")
            {
                Environment.Exit(0);
            }
            else if(userInput == "N" || userInput == "NO")
            {
                Presentation();
            }
        }
    }
}
