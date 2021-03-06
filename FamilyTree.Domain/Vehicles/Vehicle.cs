namespace Sitline.Training.FamilyTree.Vehicles
{
    public abstract class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public int MaxSpeed { get; set; }
        public int Wheels { get; set; }
        public string Combustible { get; set; }

        public enum Directions
        {
            Front,
            Back,
            Left,
            Right
        }
        public abstract void GetDirections();

        public override string ToString()
        {
            return $"{VehicleType} with: " +
                $"\n{Wheels} wheels " +
                $"\nA maximum speed of {MaxSpeed}" +
                $"\n{Combustible} as a combustible \n";
        }
        public override bool Equals(object obj)
        {
            var other = obj as Vehicle;

            if (other == null)
                return false;

            return VehicleId == other.VehicleId
                && VehicleType == other.VehicleType 
                && Wheels == other.Wheels 
                && MaxSpeed == other.MaxSpeed 
                && Combustible == other.Combustible;
        }
        public override int GetHashCode()
        {
            int hashId = VehicleId.GetHashCode();
            int hashType = VehicleType == null ? 0 : VehicleType.GetHashCode();
            int hashWheels = Wheels.GetHashCode();
            int hashSpeed = MaxSpeed.GetHashCode();
            int hashCombust = Combustible.GetHashCode();

            return hashType ^ hashWheels ^ hashSpeed ^ hashCombust;
        }
    }

}
