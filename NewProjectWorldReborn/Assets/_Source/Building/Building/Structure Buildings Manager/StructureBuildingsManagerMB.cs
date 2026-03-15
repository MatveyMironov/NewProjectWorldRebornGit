using ConstructionGridSystem;
using System;
using UnityEngine;

namespace BuildingSystem
{
    public class StructureBuildingsManagerMB : MonoBehaviour, IStructureBuildingsManager
    {
        private IStructureBuildingsManager _manager;

        public Building[] Buildings => _manager.Buildings;

        public event Action<Building> OnBuildingAdded
        {
            add =>_manager.OnBuildingAdded += value;
            remove => _manager.OnBuildingAdded -= value;
        }

        public event Action<Building> OnBuildingRemoved
        {
            add => _manager.OnBuildingRemoved += value;
            remove => _manager.OnBuildingRemoved -= value;
        }

        private void Awake()
        {
            _manager = new StructureBuildingsManager();
        }

        public bool TryAddStructureBuilding(BuildingStructure structure, Building building)
        {
            return _manager.TryAddStructureBuilding(structure, building);
        }

        public bool TryRemoveBuildingInterior(BuildingStructure structure)
        {
            return _manager.TryRemoveBuildingInterior(structure);
        }

        public bool TryGetBuildingInterior(BuildingStructure structure, out Building building)
        {
            return _manager.TryGetBuildingInterior(structure, out building);
        }
    }
}