using FamilyTree.Data;
using Microsoft.EntityFrameworkCore;
using Sitline.Training.FamilyTree;
using Sitline.Training.FamilyTree.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sitline.Training.TestConsole
{
    class TestConsole
    {
        private static FamilyTreeContext _context = new FamilyTreeContext();
        static void Main()
        {
            //AddPersonsByName("Dani","Mihai","Tomy","Ovidiu");
            //AddVariousTypes();
            ////RetrieveAndDeleteAPerson();
            GetPerson();
            //AddAFriendToAPersonById(2);
            //GetFriendsForAPerson();
            //GetFriendForAPersonById(2);
            //AddAPersonWithADog();
            Console.WriteLine("Press any key...");
        }

        private static void AddVariousTypes()
        {
            _context.AddRange(new Person { FirstName = "Alehandro" },
                              new Car { MaxSpeed = 300 });
            _context.SaveChanges();
        }

        private static void AddPersonsByName(params string[] names)
        {
            foreach(string name in names)
            {
                _context.Persons.Add(new Person { FirstName = name });
            }
            _context.SaveChanges();
        }

        private static void GetPerson()
        {
            var persons = _context.Persons.ToList();
            Console.WriteLine($"Persons count is : {persons.Count}");
            foreach(var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }
        }

        private static void RetrieveAndDeleteAPerson()
        {
            var persons = _context.Persons.ToList();
            foreach(var person in persons)
            {
                if (person.FirstName == "Andrei")
                    _context.Remove(person);
            }
            _context.SaveChanges();
        }

        private static void AddAFriendToAPersonById(int id)
        {
            var person = _context.Persons.FirstOrDefault(p=>p.Id==id);
            person.Friends.Add(new Friend { Name = "Sasuke" });
            _context.SaveChanges();
        }

        private static void GetFriendsForAPerson()
        {
            var friend = _context.Friends.Include(f => f.Persons).FirstOrDefault();
            Console.WriteLine(friend.Name);
        }

        private static void GetFriendForAPersonById(int id)
        {
            var person = _context.Persons.Include(f=>f.Friends).FirstOrDefault(p => p.Id == id);
            var friend = person.Friends.Count;
            Console.WriteLine(friend);
        }
        private static void AddAPersonWithADog()
        {
            var person = new Person { FirstName = "Kakashi", LastName = "Hatake" };
            person.Dog = new Dog { Name = "Pakkun" };
            _context.Persons.Add(person);
            _context.SaveChanges();
            Console.WriteLine($"Person {person.FirstName} have the dog {person.Dog.Name}");
        }
    }
}

//FamilyTreeActionHandler familyTreeActionHandler = new FamilyTreeActionHandler();
//bool menu = true;
//while(menu)
//{
//    Console.WriteLine("Choose the option :\n1. Add Person 2. Add a children to a person 3. Get childrens \n" +
//                                          "4. Search a person by name 5. Show all persons 6. Show adults \n" +
//                                          "7. Show children 8. Add vehicle to a person 9. Get vehicle \n" +
//                                          "10. Exit");
//    string option = Console.ReadLine();
//    familyTreeActionHandler.Handle(option);
//}