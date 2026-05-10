using ConstructionGridSystem;
using System;

namespace BuildingSystem
{
    public interface IStructureBuildingsManager
    {
        Building[] Buildings { get; }
        event Action<Building> OnBuildingAdded;
        event Action<Building> OnBuildingRemoved;

        bool TryAddStructureBuilding(BuildingStructure structure, Building building);
        bool TryRemoveBuildingInterior(BuildingStructure structure);
        bool TryGetBuildingInterior(BuildingStructure structure, out Building building);
    }
}