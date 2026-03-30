using ServiceSystem;
using ManufactureSystem;
using EmployerSystem;
using System;

namespace BuildingInteriorSystem
{
    public class BuildingInterior
    {
        public BuildingInterior(string name,
                                string description,
                                IEmployer employer = null,
                                IManufacture manufacture = null,
                                ServiceProvider serviceProvider = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));

            Employer = employer;
            Manufacture = manufacture;
            ServiceProvider = serviceProvider;
        }

        public string Name { get; }
        public string Description { get; }

        public IEmployer Employer { get; }
        public IManufacture Manufacture { get; }
        public ServiceProvider ServiceProvider { get; }
    }
}