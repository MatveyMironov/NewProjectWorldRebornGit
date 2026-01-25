using ConstructionGridSystem;

namespace BuildingSystem
{
    public interface IStructureBuildingsManager
    {
        bool TryAddStructureBuilding(ConstructedBuilding structure, Building building);
        bool TryRemoveBuildingInterior(ConstructedBuilding structure);
        bool TryGetBuildingInterior(ConstructedBuilding structure, out Building building);
    }
}