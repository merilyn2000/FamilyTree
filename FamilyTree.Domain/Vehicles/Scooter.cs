using System;

namespace Sitline.Training.FamilyTree.Vehicles
{
    public class Scooter : Vehicle
    {
        public override void GetDirections()
        {
            Directions front = Directions.Front;
            Directions back = Directions.Back;
            Directions left = Directions.Left;
            Directions right = Directions.Right;
            Console.WriteLine($"The scooter can go in the directions : {front} , {back} , {right} and {left} ");
        }
    }
}
