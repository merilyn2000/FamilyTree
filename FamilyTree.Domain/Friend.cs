using System.Collections.Generic;

namespace Sitline.Training.FamilyTree
{
    public class Friend
    {
        public int FriendId { get; set; }
        public string Name { get; set; }
        public List<Person> Persons { get; set; } = new List<Person>();

        public override string ToString()
        {
            return $"Id :{FriendId} , Name : {Name}";
        }
    }
}
