using Sitline.Training.FamilyTree.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sitline.Training.FamilyTree
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DeathDate { get; set; }
        [NotMapped]
        public IList<string> ChildrensIds { get; set; } = new List<string>();
        public List<Friend> Friends { get; set; } = new List<Friend>();
        public Dog Dog { get; set; }
        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - BirthDate.Year - 1;
                if (DateTime.Now.Month > BirthDate.Month)
                {
                    age = DateTime.Now.Year - BirthDate.Year;
                }
                if (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day >= BirthDate.Day)
                {
                    age = DateTime.Now.Year - BirthDate.Year;
                }
                return age; 
            }
        }
        public int Sex { get; set; }
        public string PairId { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public override string ToString()
        {
            return $"The person {FirstName} {LastName} have :" +
                   $"\nId : {Id}" +
                   $"\nBirth Date and Deadth Date : {BirthDate} - {DeathDate}" +
                   $"\nSex : {Sex} And Pair : {PairId}" +
                   $"\nAnd {Vehicles.Count} vehicles";
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;

            if (other == null)
                return false;

            return PersonId == other.PersonId
                && FirstName == other.FirstName
                && Age == other.Age
                && LastName == other.LastName
                && Id == other.Id
                && Sex == other.Sex
                && PairId == other.PairId
                && BirthDate == other.BirthDate
                && DeathDate == other.DeathDate;
        }
        public override int GetHashCode()
        {
            int hashPersonId = PersonId.GetHashCode();
            int hashFName = FirstName == null ? 0 : FirstName.GetHashCode();
            int hashLName = LastName == null ? 0 : LastName.GetHashCode();
            int hashId = Id.GetHashCode();
            int hashSex = Sex.GetHashCode();
            int hashPair = PairId.GetHashCode();
            int hashBDate = BirthDate.GetHashCode();
            int hashDDate = DeathDate.GetHashCode();

            return hashPersonId ^ hashFName ^ hashLName ^ hashId ^ hashSex ^ hashPair ^ hashBDate & hashDDate;
        }
    }
}
