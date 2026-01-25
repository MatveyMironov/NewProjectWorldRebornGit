using ConstructionGridSystem;
using System;
using System.Collections.Generic;

namespace BuildingSystem
{
    public class StructureBuildingsManager : IStructureBuildingsManager
    {
        private readonly IBuildingSelectionActionsManager _buildingSelectionActionsManager;

        public StructureBuildingsManager(IBuildingSelectionActionsManager buildingSelectionActionsManager)
        {
            _buildingSelectionActionsManager = buildingSelectionActionsManager ?? throw new ArgumentNullException(nameof(buildingSelectionActionsManager));
        }

        private readonly Dictionary<ConstructedBuilding, Building> _structureBuildings = new();

        public bool TryAddStructureBuilding(ConstructedBuilding structure, Building building)
        {
            if (_structureBuildings.TryAdd(structure, building))
            {
                _buildingSelectionActionsManager.TryAddBuildingSelectionAction(building);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingInterior(ConstructedBuilding structure)
        {
            if (_structureBuildings.Remove(structure, out Building building))
            {
                _buildingSelectionActionsManager.TryRemoveBuildingSelectionAction(building);
                return true;
            }

            return false;
        }

        public bool TryGetBuildingInterior(ConstructedBuilding structure, out Building building)
        {
            return _structureBuildings.TryGetValue(structure, out building);
        }
    }
}