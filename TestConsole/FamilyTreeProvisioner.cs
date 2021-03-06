using Sitline.Training.FamilyTree;
using Sitline.Training.FamilyTree.Vehicles;
using System.Collections.Generic;

namespace Sitline.Training.TestConsole
{
    public class FamilyTreeProvisioner
    {
        public void AddPersons(FamilyGraph familyGraph)
        {
            Person person1 = new Person()
            {
                PersonId = "1",
                FirstName = "Paul",
                LastName = "Ivan",
                Vehicles = new List<Vehicle>()
                {
                    new Car()
                    {
                        VehicleType = "Car",
                        MaxSpeed = 220,
                        Combustible = "Gasoline",
                        Wheels = 4
                    },
                    new Car()
                    {
                        VehicleType = "Car",
                        MaxSpeed = 300,
                        Combustible = "Current",
                        Wheels = 4
                    }
                }
            };

            Person person2 = new Person()
            {
                PersonId = "2",
                FirstName = "Alex",
                LastName = "Ivan",
                Vehicles = new List<Vehicle>()
                {
                    new Scooter()
                    {
                        VehicleType = "Scooter",
                        MaxSpeed = 100,
                        Combustible = "Current",
                        Wheels = 2
                    }
                }
            };

            Person person3 = new Person()
            {
                PersonId = "3",
                FirstName = "Sergiu",
                LastName = "Ivan",
                Sex = 1,
                PairId = "4",
                Vehicles = new List<Vehicle>()
                {
                    new Train()
                    {
                    VehicleType = "Train",
                    MaxSpeed = 180,
                    Combustible = "Gasoline",
                    Wheels = 100
                    }
                }
            };

            Person person4 = new Person()
            {
                PersonId = "4",
                FirstName = "Delia",
                LastName = "Ivan",
                Sex = 0,
                PairId = "3",
                Vehicles = new List<Vehicle>()
                {
                    new Motorcycle()
                    {
                    VehicleType = "Motorcycle",
                    MaxSpeed = 160,
                    Combustible = "Gasoline",
                    Wheels = 2
                    }
                }
            };

            familyGraph.AddNewPerson(person1);
            familyGraph.AddNewPerson(person2);
            familyGraph.AddNewPerson(person3);
            familyGraph.AddNewPerson(person4);
        }
    }
}
