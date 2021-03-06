using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitline.Training.FamilyTree;

namespace FamilyTreeTest
{
    [TestClass]
    public class FamilyGraphTest
    {
        private readonly FamilyGraph familyGraph = new FamilyGraph();
        private readonly FamilyTreeTestProvisioner familyTreeTestProvisioner = new FamilyTreeTestProvisioner();

        [TestMethod]
        public void Given_NewFamilyTree_When_APersonWithACarIsAdded_Then_TheVehicleIsRetrivedCorrectForThePerson()
        {
            const string personId = "1";
            familyTreeTestProvisioner.AddPersons(familyGraph);
            var expectedVehicles = TestData.GetExpectedVehiclesForPersonWithId1();
            var actualVehicles = familyGraph.GetVehicles(personId);
            Assert.AreEqual(2, actualVehicles.Count);
            CollectionAssert.AreEqual(expectedVehicles,actualVehicles);
        }

        [TestMethod]
        public void Given_NewFamilyTree_When_AChildIsAddedToAPair_Then_TheChildIsRetrivedCorrectly()
        {
            const string fatherId = "3";
            const string childId = "6";
            familyTreeTestProvisioner.AddPersons(familyGraph);
            var expectedChild = TestData.GetExpectedChild();
            familyGraph.AddChildToPair(fatherId, expectedChild);
            var children = familyGraph.GetChildren(fatherId);
            Assert.AreEqual(1, children.Count);
            var actualChild = familyGraph.GetAPersonById(childId);
            Assert.AreEqual(expectedChild, actualChild);
        }

        [TestMethod]
        public void Given_NewFamilyTree_When_SomePersonsAreAdded_Then_ThePersonsAreRetrivedCorrectly()
        {
            familyTreeTestProvisioner.AddPersons(familyGraph);
            var expectedPersons = TestData.GetExpectedPersons();
            var actualPersons = familyGraph.GetAllPersons();
            Assert.AreEqual(5, expectedPersons.Count);
            CollectionAssert.AreEqual(expectedPersons, actualPersons);
        }

        [TestMethod]
        public void Given_NewFamilyTree_When_SomePersonsAreAdded_Then_OnePersonIsRetrivedCorrectlyByFirstName()
        {
            const string personName = "Sergiu";
            familyTreeTestProvisioner.AddPersons(familyGraph);
            var expectedPerson = TestData.GetExpectedPersonForTheNameSergiu();
            var actualPerson = familyGraph.GetAPersonByName(personName);
            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [TestMethod]
        public void Given_NewFamilyTree_When_SomePersonsAreAdded_Then_TheAdultsAreRetrivedCorrectly()
        {
            familyTreeTestProvisioner.AddPersons(familyGraph);
            var expectedAdults = TestData.GetExpectedAdults();
            var actualAdults = familyGraph.GetAdults();
            CollectionAssert.AreEqual(expectedAdults,actualAdults);
        }

        [TestMethod]
        public void Given_NewFamilyTree_When_SomePersonsAreAdded_Then_TheChildrenAreRetrivedCorrectly()
        {
            familyTreeTestProvisioner.AddPersons(familyGraph);
            var expectedChildren = TestData.GetExpectedChildren();
            var actualChildren = familyGraph.GetChildren();
            CollectionAssert.AreEqual(expectedChildren, actualChildren);
        }
    }
}
