using Microsoft.EntityFrameworkCore;
using Sitline.Training.FamilyTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Data
{
    public class BusinessDataLogic
    {
        private FamilyTreeContext _context;

        public BusinessDataLogic(FamilyTreeContext context)
        {
            _context = context;
        }

        public BusinessDataLogic()
        {
            _context = new FamilyTreeContext();
        }

        public int AddPersonsByName(params string[] names)
        {
            foreach(var name in names)
            {
                _context.Persons.Add(new Person { FirstName = name });
            }
            var dbResult = _context.SaveChanges();
            return dbResult;
        }

        public int InsertNewPerson(Person person)
        {
            _context.Persons.Add(person);
            var dbResult = _context.SaveChanges();
            return dbResult;
        }

        public Person GetPersonWithVehicles(int personID)
        {
            var personWithVehicle = _context.Persons.Where(p => p.Id == personID)
                                                    .Include(s => s.Vehicles)
                                                    .FirstOrDefault();
            return personWithVehicle;
        }

        public List<Friend> GetFriendsForAPersonById(int id)
        {
            var person = _context.Persons.Include(p => p.Friends).FirstOrDefault(p => p.Id == id);
            return person.Friends;
        }

        public Dog GetDogForAPersonById(int id)
        {
            var person = _context.Persons.Include(p => p.Dog).FirstOrDefault(p => p.Id == id);
            return person.Dog;
        }

        //var person = _context.Persons.Include(f => f.Friends).FirstOrDefault(p => p.Id == id);
        //var friend = person.Friends.Count;
        //Console.WriteLine(friend);
    }
}
