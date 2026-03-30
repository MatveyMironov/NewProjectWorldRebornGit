using ServiceSystem;
using System;

namespace BuildingInteriorSystem
{
    public class BuildingInterior
    {
        public BuildingInterior(string name,
                                string description,
                                ServiceProvider serviceProvider = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ServiceProvider = serviceProvider;
        }

        public string Name { get; }
        public string Description { get; }

        public ServiceProvider ServiceProvider { get; }
    }
}