using ConstructionGridSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public class StructureBuildingsManager : IStructureBuildingsManager
    {
        private readonly IBuildingInteractionsManager _buildingSelectionActionsManager;

        public StructureBuildingsManager(IBuildingInteractionsManager buildingSelectionActionsManager)
        {
            _buildingSelectionActionsManager = buildingSelectionActionsManager ?? throw new ArgumentNullException(nameof(buildingSelectionActionsManager));
        }

        private readonly Dictionary<BuildingStructure, Building> _structureBuildings = new();

        public event Action<Building> OnBuildingAdded;
        public event Action<Building> OnBuildingRemoved;

        public bool TryAddStructureBuilding(BuildingStructure structure, Building building)
        {
            if (_structureBuildings.TryAdd(structure, building))
            {
                _buildingSelectionActionsManager.TryAddBuildingInteraction(building);
                Debug.Log($"Building {building} for structure {structure} was added");
                OnBuildingAdded?.Invoke(building);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingInterior(BuildingStructure structure)
        {
            if (_structureBuildings.Remove(structure, out Building building))
            {
                _buildingSelectionActionsManager.TryRemoveBuildingInteraction(building);
                Debug.Log($"Building {building} for structure {structure} was removed");
                OnBuildingRemoved?.Invoke(building);
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