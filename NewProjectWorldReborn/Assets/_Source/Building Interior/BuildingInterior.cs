using ServiceSystem;
using ManufactureSystem;
using System;

namespace BuildingInteriorSystem
{
    public class BuildingInterior
    {
        public BuildingInterior(string name,
                                string description,
                                IManufacture manufacture = null,
                                ServiceProvider serviceProvider = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));

            Manufacture = manufacture;
            ServiceProvider = serviceProvider;
        }

        public string Name { get; }
        public string Description { get; }

        public IManufacture Manufacture { get; }
        public ServiceProvider ServiceProvider { get; }
    }
}