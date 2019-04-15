using System;
using System.Collections;
using System.Collections.Generic;

namespace CarParkApp
{
    public class CarPark
    {
        private static Customer[] cars = new Customer[11];

        public static void InsertCar(Customer customerCar)
        {
            try
            {
                int availableParkinSpot = FindParkinSpot("");
                if (availableParkinSpot == -1)
                    Console.WriteLine("No more spaces available.\n");
                else
                    Console.WriteLine($"Car will be parked in the parking space n: {availableParkinSpot}\n");
                cars[availableParkinSpot] = customerCar;
            }
            catch (IndexOutOfRangeException) { }
        }

        public static void RemoveCar(string licencePlate)
        {
            int foundCar = FindParkinSpot(licencePlate);
            if (foundCar == -1)
            {
                Console.WriteLine("Car not found.\n");
                return;
            }
            Console.WriteLine("Car found in the spot n: {0} of Customer : {1} , was removed.\n", Array.IndexOf(cars, cars[foundCar]), cars[foundCar].Name);
            cars[foundCar] = null;
        }
        public static void FindGuestCar(string guestName)
        {
            for (int i = 1; i < cars.Length; i++)
            {
                try
                {
                    if (cars[i].Name == guestName)
                    {
                        Console.WriteLine($"Customer: {cars[i].Name} , Licence Plate {cars[i].LicencePlate}, is parked in space N: {Array.IndexOf(cars, cars[i])}");
                    }
                    else
                        Console.WriteLine("The name was not found.\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("Guest name not found in the system.\n");
                }
            }
        }
        public static void ListAllCars()
        {
            for (int i = 1; i < cars.Length; i++)
            {
                try
                {
                    Console.WriteLine("List of cars parked:\n");
                    Console.WriteLine("Parking Space Number {0}, Guest name {1}, Phone Number {2}, Licence Plate {3}\n", Array.IndexOf(cars, cars[i]), cars[i].Name, cars[i].PhoneNumber, cars[i].LicencePlate);
                }

                catch (NullReferenceException)
                {
                    Console.WriteLine("There are no cars parked\n");
                }
            }
        }

        public static int FindParkinSpot(string licencePlate)
        {
            int result = -1;
            for (int index = 1; index < cars.Length; index++)
            {
                try
                {
                    if (licencePlate == "" && cars[index] == null)
                    {
                        result = index;
                        return result;
                    }
                    else if (cars[index].LicencePlate == licencePlate)
                    {
                        result = index;
                        break;
                    }
                }
                catch (NullReferenceException)
                {
                    return result;
                }
            }
            return result;
        }
    }
}
