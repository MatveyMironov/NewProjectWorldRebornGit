using BuildingInfoSystem;
using ConstructionGridSystem;
using System;

namespace BuildingSystem
{
    public class Building
    {
        public Building(IBuildingConfiguration configuration, BuildingStructure structure, IBuildingInfo info)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Structure = structure ?? throw new ArgumentNullException(nameof(structure));
            Info = info ?? throw new ArgumentNullException(nameof(info));
        }

        public IBuildingConfiguration Configuration { get; }
        public BuildingStructure Structure { get; }
        public IBuildingInfo Info { get; }
    }
}