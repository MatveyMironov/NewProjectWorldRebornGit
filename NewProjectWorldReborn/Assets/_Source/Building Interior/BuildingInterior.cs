using ManufactureSystem;
using EmployerSystem;
using System;

namespace BuildingInteriorSystem
{
    public class BuildingInterior
    {
        public BuildingInterior(string name,
                                string description,
                                IManufacture manufacture = null)
                                IEmployer employer = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));

            Manufacture = manufacture;
            Employer = employer;
        }

        public string Name { get; }
        public string Description { get; }

        public IManufacture Manufacture { get; }
        public IEmployer Employer { get; }
    }
}