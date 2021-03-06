using Sitline.Training.FamilyTree;
using Sitline.Training.FamilyTree.Vehicles;
using System;
using System.Collections.Generic;

namespace FamilyTreeTest
{
    class TestData
    {
        public static List<Vehicle> GetExpectedVehiclesForPersonWithId1()
        {
            var cars = new List<Vehicle>()
            {
                new Car()
                {
                    VehicleType = "Car",
                    MaxSpeed = 220,
                    Combustible = "Gasoline",
                    Wheels = 4
                },
                new Car()
                {
                    VehicleType = "Car",
                    MaxSpeed = 300,
                    Combustible = "Current",
                    Wheels = 4
                }
            };
            return cars;
        }
        public static Person GetExpectedChild()
        {
            var child = new Person()
            {
                PersonId = "6",
                FirstName = "Mihai",
                LastName = "Ivan"
            };
            return child;
        }
        public static List<Person> GetExpectedPersons()
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    PersonId = "1",
                    FirstName = "Paul",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(2000, 06, 24),
                    DeathDate = new DateTime(2020, 07, 09),
                    ChildrensIds = null,
                    PairId = "7",
                    Vehicles = new List<Vehicle>()
                    {
                        new Car()
                        {
                            VehicleType = "Car",
                            MaxSpeed = 220,
                            Combustible = "Gasoline",
                            Wheels = 4
                        },
                        new Car()
                        {
                            VehicleType = "Car",
                            MaxSpeed = 300,
                            Combustible = "Current",
                            Wheels = 4
                        }
                    }
                },
                new Person()
                {
                    PersonId = "2",
                    FirstName = "Alex",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(2009, 08, 10),
                    DeathDate = new DateTime(2020, 01, 09),
                    ChildrensIds = null,
                    PairId = "6",
                    Vehicles = new List<Vehicle>()
                    {
                        new Scooter()
                        {
                            VehicleType = "Scooter",
                            MaxSpeed = 100,
                            Combustible = "Current",
                            Wheels = 2
                        }
                    }
                },
                new Person()
                {
                    PersonId = "3",
                    FirstName = "Sergiu",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(1998, 09, 08),
                    DeathDate = new DateTime(2020, 08, 07),
                    PairId = "4",
                    ChildrensIds = new List<string>(),
                    Vehicles = new List<Vehicle>()
                    {
                        new Train()
                        {
                        VehicleType = "Train",
                        MaxSpeed = 180,
                        Combustible = "Gasoline",
                        Wheels = 100
                        }
                    }
                },
                new Person()
                {
                    PersonId = "4",
                    FirstName = "Delia",
                    LastName = "Ivan",
                    Sex = 0,
                    BirthDate = new DateTime(1997, 09, 02),
                    DeathDate = new DateTime(2020, 08, 02),
                    PairId = "3",
                    ChildrensIds = new List<string>(),
                },
                new Person()
                {
                    PersonId = "5",
                    FirstName = "Andrei",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(2010, 09, 12),
                    DeathDate = new DateTime(2020, 08, 09),
                    PairId = "8",
                    ChildrensIds = new List<string>(),
                    Vehicles = new List<Vehicle>()
                    {
                        new Motorcycle()
                        {
                            VehicleType = "Motorcylce",
                            MaxSpeed = 123,
                            Combustible = "Gasoline",
                            Wheels = 2
                        }
                    }
                }
            };
            return persons;
        }
        public static Person GetExpectedPersonForTheNameSergiu()
        {
            var person = new Person()
            {
                PersonId = "3",
                FirstName = "Sergiu",
                LastName = "Ivan",
                Sex = 1,
                BirthDate = new DateTime(1998, 09, 08),
                DeathDate = new DateTime(2020, 08, 07),
                PairId = "4",
                ChildrensIds = new List<string>(),
                Vehicles = new List<Vehicle>()
                {
                    new Train()
                    {
                    VehicleType = "Train",
                    MaxSpeed = 180,
                    Combustible = "Gasoline",
                    Wheels = 100
                    }
                }
            };
            return person;
        }
        public static List<Person> GetExpectedAdults()
        {
            var adults = new List<Person>()
            {
                new Person()
                {
                    PersonId = "1",
                    FirstName = "Paul",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(2000, 06, 24),
                    DeathDate = new DateTime(2020, 07, 09),
                    ChildrensIds = null,
                    PairId = "7",
                    Vehicles = new List<Vehicle>()
                    {
                        new Car()
                        {
                            VehicleType = "Car",
                            MaxSpeed = 220,
                            Combustible = "Gasoline",
                            Wheels = 4
                        },
                        new Car()
                        {
                            VehicleType = "Car",
                            MaxSpeed = 300,
                            Combustible = "Current",
                            Wheels = 4
                        }
                    }
                },
                new Person()
                {
                    PersonId = "3",
                    FirstName = "Sergiu",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(1998, 09, 08),
                    DeathDate = new DateTime(2020, 08, 07),
                    PairId = "4",
                    ChildrensIds = new List<string>(),
                    Vehicles = new List<Vehicle>()
                    {
                        new Train()
                        {
                        VehicleType = "Train",
                        MaxSpeed = 180,
                        Combustible = "Gasoline",
                        Wheels = 100
                        }
                    }
                },
                new Person()
                {
                    PersonId = "4",
                    FirstName = "Delia",
                    LastName = "Ivan",
                    Sex = 0,
                    BirthDate = new DateTime(1997, 09, 02),
                    DeathDate = new DateTime(2020, 08, 02),
                    PairId = "3",
                    ChildrensIds = new List<string>(),
                }
            };
            return adults;
        }
        public static List<Person> GetExpectedChildren()
        {
            var children = new List<Person>()
            {
                new Person()
                {
                    PersonId = "2",
                    FirstName = "Alex",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(2009, 08, 10),
                    DeathDate = new DateTime(2020, 01, 09),
                    ChildrensIds = null,
                    PairId = "6",
                    Vehicles = new List<Vehicle>()
                    {
                        new Scooter()
                        {
                            VehicleType = "Scooter",
                            MaxSpeed = 100,
                            Combustible = "Current",
                            Wheels = 2
                        }
                    }
                },
                new Person()
                {
                    PersonId = "5",
                    FirstName = "Andrei",
                    LastName = "Ivan",
                    Sex = 1,
                    BirthDate = new DateTime(2010, 09, 12),
                    DeathDate = new DateTime(2020, 08, 09),
                    PairId = "8",
                    ChildrensIds = new List<string>(),
                    Vehicles = new List<Vehicle>()
                    {
                        new Motorcycle()
                        {
                        VehicleType = "Motorcylce",
                        MaxSpeed = 123,
                        Combustible = "Gasoline",
                        Wheels = 2
                        }
                    }
                }
            };
            return children;
        }
    }  
}
