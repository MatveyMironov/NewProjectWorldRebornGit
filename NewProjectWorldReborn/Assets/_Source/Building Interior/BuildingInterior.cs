using EmployerSystem;
using System;

namespace BuildingInteriorSystem
{
    public class BuildingInterior
    {
        public BuildingInterior(string name,
                                string description,
                                IEmployer employer = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));

            Employer = employer;
        }

        public string Name { get; }
        public string Description { get; }

        public IEmployer Employer { get; }
    }
}