using ConstructionGridSystem;

namespace BuildingSystem
{
    public interface IStructureBuildingsManager
    {
        bool TryAddStructureBuilding(BuildingStructure structure, Building building);
        bool TryRemoveBuildingInterior(BuildingStructure structure);
        bool TryGetBuildingInterior(BuildingStructure structure, out Building building);
    }
}