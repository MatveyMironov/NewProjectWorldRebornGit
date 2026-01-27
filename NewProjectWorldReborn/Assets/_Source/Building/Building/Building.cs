using BuildingInfoSystem;
using ConstructionGridSystem;
using System;

namespace BuildingSystem
{
    public class Building
    {
        public Building(ConstructedBuilding structure, IBuildingInfo info)
        {
            Structure = structure ?? throw new ArgumentNullException(nameof(structure));
            Info = info ?? throw new ArgumentNullException(nameof(info));
        }

        public ConstructedBuilding Structure { get; }
        public IBuildingInfo Info { get; }
    }
}