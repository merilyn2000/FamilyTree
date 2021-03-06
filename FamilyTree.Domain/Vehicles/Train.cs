using System;
using System.Collections.Generic;
using System.Text;

namespace Sitline.Training.FamilyTree.Vehicles
{
    public class Train : Vehicle
    {
        public override void GetDirections()
        {
            Directions front = Directions.Front;
            Directions back = Directions.Back;
            Console.WriteLine($"The train can go in the directions : {front} and {back}");
        }
    }
}
