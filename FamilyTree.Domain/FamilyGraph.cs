using Sitline.Training.FamilyTree.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitline.Training.FamilyTree
{
    public class FamilyGraph
    {
        private readonly List<Person> persons;

        public FamilyGraph()
        {
            persons = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            persons.Add(person);
        }

        public void AddChildToPair(string personId, Person child)
        {
            Person person1 = persons.FirstOrDefault(p => p.PersonId == personId);
            Person person2 = persons.FirstOrDefault(p => p.PersonId == person1.PairId);
            if(person1.Sex!=person2.Sex)
            {
                person1.ChildrensIds.Add(child.PersonId);
                persons.Add(child);
                person2.ChildrensIds.Add(child.PersonId);
                persons.Add(child);
            }
        }

        public IList<string> GetChildren(string parentId)
        {
            Person person = persons.FirstOrDefault(p => p.PersonId == parentId);
            return person.ChildrensIds;
        }

        public void AddVehicleToPerson(string personId, Vehicle vehicle)
        {
            Person person = persons.FirstOrDefault(p => p.PersonId == personId);
            person.Vehicles.Add(vehicle);
        }

        public List<Vehicle> GetVehicles(string personId)
        {
            Person person = persons.FirstOrDefault(p => p.PersonId == personId);
            return person.Vehicles;
        }

        public List<Person> GetAllPersons()
        {
            return persons;
        }

        public Person GetAPersonByName(string Name)
        {
            Person person = persons.FirstOrDefault(n => n.FirstName == Name);
            return person;
        }

        public Person GetAPersonById(string id)
        {
            Person person = persons.FirstOrDefault(n => n.PersonId == id);
            return person;
        }

        public List<Person> GetAdults()
        {
            var adults = new List<Person>();
            foreach(var adult in persons)
            {
                adults = persons.FindAll(p => p.Age >= 18);
            }
            return adults; 
        }

        public List<Person> GetChildren()
        {
            var children = new List<Person>();
            foreach (var child in persons)
            {
                children = persons.FindAll(p => p.Age < 18);
            }
            return children;
        }

        //-----------------------------------------------------------------------

        public void LogChildrenDirectionsToTheConsole(string parentId)
        {
            Person person = persons.FirstOrDefault(p => p.PersonId == parentId);
            var childrenIds = person.ChildrensIds;
            foreach (var childId in childrenIds)
            {
                Person child = persons.FirstOrDefault(p => p.PersonId == childId);
                Console.WriteLine(child.Id + "\n" + child.BirthDate + "\n" + child.FirstName + "\n" + child.LastName + "\n"
                               + child.DeathDate + "\n" + child.ChildrensIds);
            }
        }
        public void LogVehiclesDirectionsToTheConsole(string personId)
        {
            Person person = persons.FirstOrDefault(p => p.PersonId == personId);
            var vehicles = person.Vehicles;
            foreach (var vehicle in vehicles)
            {
                if (vehicle.VehicleType == "Car")
                {
                    Console.WriteLine($"{person.FirstName} own a {vehicle}");
                    Car car = new Car();
                    car.GetDirections();
                }
                else if (vehicle.VehicleType == "Motorcycle")
                {
                    Console.WriteLine($"{person.FirstName} own a {vehicle}");
                    Motorcycle motorcycle = new Motorcycle();
                    motorcycle.GetDirections();
                }
                else if (vehicle.VehicleType == "Scooter")
                {
                    Console.WriteLine($"{person.FirstName} own a {vehicle}");
                    Scooter scooter = new Scooter();
                    scooter.GetDirections();
                }
                else if (vehicle.VehicleType == "Train")
                {
                    Console.WriteLine($"{person.FirstName} own a {vehicle}");
                    Train train = new Train();
                    train.GetDirections();
                }
            }
        }
        public void LogAPersonByNameToTheConsole(string Name)
        {
            var person = persons.FirstOrDefault(n => n.FirstName == Name);
            Console.WriteLine($"\n{person}");
        }
        public void LogAllPersonsToTheConsole()
        {
            foreach (var person in persons)
                Console.WriteLine($"\n{person}");
        }

        public void LogAdultsToTheConsole()
        {
            foreach (var person in persons)
            {
                var age = person.Age;
                if (age >= 18)
                {
                    Console.WriteLine($"\n{person}");
                }
            }
        }

        public void LogChildrenToTheConsole()
        {
            foreach (var person in persons)
            {
                var age = person.Age;
                if (age < 18)
                {
                    Console.WriteLine($"\n{person}");
                }
            }
        }
    }
}