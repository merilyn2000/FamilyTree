using Sitline.Training.FamilyTree;
using Sitline.Training.FamilyTree.Vehicles;
using System;
using System.Collections.Generic;

namespace Sitline.Training.TestConsole
{
    internal class FamilyTreeActionHandler
    {
        private readonly FamilyGraph familyTree = new FamilyGraph();
        private readonly FamilyTreeProvisioner familyTreeProvisioner = new FamilyTreeProvisioner();

        internal bool Handle(string actionId)
        {
            switch (actionId)
            {
                case "0":
                    {
                        AddPersons();
                        break;
                    }
                case "1":
                    {
                        AddNewPerson();
                        break;
                    }
                case "2":
                    {
                        AddChildrenToPair();
                        break;
                    }
                case "3":
                    {
                        GetChildren();
                        break;
                    }
                case "4":
                    {
                        SearchByName();
                        break;
                    }
                case "5":
                    {
                        familyTree.GetAllPersons();
                        break;
                    }
                case "6":
                    {
                        familyTree.GetAdults();
                        break;
                    }
                case "7":
                    {
                        familyTree.GetChildren();
                        break;
                    }
                case "8":
                    {
                        AddVehicleToPerson(null);
                        break;
                    }
                case "9":
                    {
                        GetVehicle();
                        break;
                    }
                case "10":
                    {
                        return false;
                    }
            }
            Console.WriteLine("\n");
            return false;
        }
        internal bool CarHandler()
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Choose the option :\n1. Car 2. Motorcycle 3. Scooter 4. Exit \n");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        {
                            Vehicle car = ReadCar("car :");
                            AddVehicleToPerson(car);
                            break;
                        }
                    case "2":
                        {
                            Vehicle motorcycle = ReadMotorcycle("motorcycle :");
                            AddVehicleToPerson(motorcycle);
                            break;
                        }
                    case "3":
                        {
                            Vehicle scooter = ReadScooter("scooter :");
                            AddVehicleToPerson(scooter);
                            break;
                        }
                    case "4":
                        {
                            return false;
                        }
                }
                Console.WriteLine("\n");
            }
            return false;
        }

        public void AddPersons()
        {
            familyTreeProvisioner.AddPersons(familyTree);
        }

        private void AddNewPerson()
        {
            Person p = ReadPerson("new person");
            familyTree.AddNewPerson(p);
        }
        
        private void AddChildrenToPair()
        {
            Console.WriteLine("Parent Id :");
            string parentId = Console.ReadLine();
            Person child = ReadPerson("child");

            familyTree.AddChildToPair(parentId, child);
        }

        private void GetChildren()
        {
            Console.WriteLine("The parent Id is :");
            string id = Console.ReadLine();
            familyTree.GetChildren(id);
        }

        private void AddVehicleToPerson(Vehicle vehicle)
        {
            bool ok = true;

            if (vehicle == null)
            {
                ok = CarHandler();
            }

            if (ok != false)
            {
                Console.WriteLine("Person Id :");
                string personId = Console.ReadLine();
                familyTree.AddVehicleToPerson(personId, vehicle);
            }
        }

        private void GetVehicle()
        {
            Console.WriteLine("The person Id is :");
            string id = Console.ReadLine();
            familyTree.LogVehiclesDirectionsToTheConsole(id);
        }

        private void SearchByName()
        {

            Console.WriteLine("Name :");
            string name = Console.ReadLine();
            familyTree.GetAPersonByName(name);
        }

        private DateTime ReadDate(string description)
        {
            Console.WriteLine($"{description} :");
            string dateStr = Console.ReadLine();
            string[] birthDatesplitUp = dateStr.Split('/');
            
            DateTime date = new DateTime(Convert.ToInt32(birthDatesplitUp[2]),
                                         Convert.ToInt32(birthDatesplitUp[1]),
                                         Convert.ToInt32(birthDatesplitUp[0]));
            return date;
        }

        private Person ReadPerson(string personDescription)
        {
            Console.WriteLine($"please introduce the data for {personDescription} :");

            Console.WriteLine("Id :");
            string Id = Console.ReadLine();

            DateTime birthDate = ReadDate("Birth Date :");
            
            Console.WriteLine("First name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last name :");
            string lastName = Console.ReadLine();

            DateTime deathDate = ReadDate("Death Date :");

            Console.WriteLine("Sex :");
            int sex = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Pair Id :");
            string pairId = Console.ReadLine();

            Person p = new Person()
            {
                PersonId = Id,
                BirthDate = birthDate,
                FirstName = firstName,
                LastName = lastName,
                DeathDate = deathDate,
                ChildrensIds = new List<string>(),
                Sex = sex,
                PairId = pairId
            };

            return p;
        }

        private Vehicle ReadCar(string carDescription)
        {
            Console.WriteLine($"please introduce the data for {carDescription} :");
            
            Console.WriteLine("Wheels :");
            int wheels = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Combustible :");
            string combustible = Console.ReadLine();

            Console.WriteLine("MaxSpeed");
            int maxSpeed = Convert.ToInt32(Console.ReadLine());

            Vehicle car = new Car()
            {
                VehicleType = "Car",
                Wheels = wheels,
                Combustible = combustible,
                MaxSpeed = maxSpeed,
            };

            return car;
        }

        private Vehicle ReadMotorcycle(string motorcycleDescription)
        {
            Console.WriteLine($"please introduce the data for {motorcycleDescription} :");

            Console.WriteLine("Wheels :");
            int wheels = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Combustible :");
            string combustible = Console.ReadLine();

            Console.WriteLine("MaxSpeed");
            int maxSpeed = Convert.ToInt32(Console.ReadLine());

            Vehicle motorcycle = new Motorcycle()
            {
                VehicleType = "Motorcycle",
                Wheels = wheels,
                Combustible = combustible,
                MaxSpeed = maxSpeed,
            };

            return motorcycle;
        }

        private Vehicle ReadScooter(string scooterDescription)
        {
            Console.WriteLine($"please introduce the data for {scooterDescription} :");

            Console.WriteLine("Wheels :");
            int wheels = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Combustible :");
            string combustible = Console.ReadLine();

            Console.WriteLine("MaxSpeed");
            int maxSpeed = Convert.ToInt32(Console.ReadLine());

            Vehicle scooter = new Scooter()
            {
                VehicleType = "Scooter",
                Wheels = wheels,
                Combustible = combustible,
                MaxSpeed = maxSpeed,
            };

            return scooter;
        }
    }
}
