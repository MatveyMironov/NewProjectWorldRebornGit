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

        private readonly Dictionary<BuildingStructure, Building> _structureBuildings = new();

        public bool TryAddStructureBuilding(BuildingStructure structure, Building building)
        {
            if (_structureBuildings.TryAdd(structure, building))
            {
                _buildingSelectionActionsManager.TryAddBuildingSelectionAction(building);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingInterior(BuildingStructure structure)
        {
            if (_structureBuildings.Remove(structure, out Building building))
            {
                _buildingSelectionActionsManager.TryRemoveBuildingSelectionAction(building);
                return true;
            }

            return false;
        }

        public bool TryGetBuildingInterior(BuildingStructure structure, out Building building)
        {
            return _structureBuildings.TryGetValue(structure, out building);
        }
    }
}