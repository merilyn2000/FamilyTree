using FamilyTree.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitline.Training.FamilyTree;
using System.Collections.Generic;
using System.Diagnostics;

namespace FamilyTree.Test
{
    [TestClass]
    public class DatabasesTests
    {
        [TestMethod]
        public void CanInsertPersonIntoDatabase()
        {
            using (var context = new FamilyTreeContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var person = new Person();
                context.Persons.Add(person);
                Debug.WriteLine($"Before save : {person.Id}");
                context.SaveChanges();
                Debug.WriteLine($"After save : {person.Id}");

                Assert.AreNotEqual(0, person.Id);
            }
        }
        
        [TestMethod]
        public void CanRetrieveFriendsForAPersonById()
        {
            int personId;
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanRetrieveFriendsForAPersonById");
            using (var context = new FamilyTreeContext(builder.Options))
            {
                var person = new Person { FirstName = "Dani", Friends = new List<Friend> { new Friend { Name = "Sasuke" } } };
                context.Persons.Add(person);
                context.SaveChanges();
                personId = person.Id;
            }
            using (var context2= new FamilyTreeContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context2);
                var result = bizlogic.GetFriendsForAPersonById(personId);
                Assert.AreEqual(1, result.Count);
            }
        }

        [TestMethod]
        public void CanRetrieveDogForAPersonById()
        {
            int personId;
            var expected = new Dog { Name = "Pakkun", Id = 1, PersonId = 1 };
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanRetrieveDogForAPersonById");
            using (var context =  new FamilyTreeContext(builder.Options))
            {
                var person = new Person { FirstName = "Kakashi", Dog = new Dog { Name = "Pakkun" } };
                context.Add(person);
                context.SaveChanges();
                personId = person.Id;
            }
            using (var context2=new FamilyTreeContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context2);
                var actual = bizlogic.GetDogForAPersonById(personId);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
