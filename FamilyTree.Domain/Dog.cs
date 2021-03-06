using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitline.Training.FamilyTree
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public override string ToString()
        {
            return $"Name : {Name}";
        }

        public override bool Equals(object obj)
        {
            var other = obj as Dog;

            if (other == null)
                return false;

            return Id == other.Id
                && Name == other.Name
                && PersonId == other.PersonId;
        }

        public override int GetHashCode()
        {
            int hashId = Id.GetHashCode();
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashPersonid = PersonId.GetHashCode();

            return hashId ^ hashName ^ hashPersonid;
        }
        //public override bool Equals(object obj)
        //{
        //    var other = obj as Person;

        //    if (other == null)
        //        return false;

        //    return PersonId == other.PersonId
        //        && FirstName == other.FirstName
        //        && Age == other.Age
        //        && LastName == other.LastName
        //        && Id == other.Id
        //        && Sex == other.Sex
        //        && PairId == other.PairId
        //        && BirthDate == other.BirthDate
        //        && DeathDate == other.DeathDate;
        //}
        //public override int GetHashCode()
        //{
        //    int hashPersonId = PersonId.GetHashCode();
        //    int hashFName = FirstName == null ? 0 : FirstName.GetHashCode();
        //    int hashLName = LastName == null ? 0 : LastName.GetHashCode();
        //    int hashId = Id.GetHashCode();
        //    int hashSex = Sex.GetHashCode();
        //    int hashPair = PairId.GetHashCode();
        //    int hashBDate = BirthDate.GetHashCode();
        //    int hashDDate = DeathDate.GetHashCode();

        //    return hashPersonId ^ hashFName ^ hashLName ^ hashId ^ hashSex ^ hashPair ^ hashBDate & hashDDate;
        //}
    }
}
