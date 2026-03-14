using ManufactureSystem;
using System;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingManufacturesManagerMB : MonoBehaviour, IBuildingManufacturesManager
    {
        [SerializeField] private ManufacturesManagerMB manufacturesManager;

        private IBuildingManufacturesManager _manager;

        public Building[] Buildings => _manager.Buildings;

        public event Action<Building> OnBuildingAdded
        {
            add => _manager.OnBuildingAdded += value;
            remove => _manager.OnBuildingAdded -= value;
        }

        public event Action<Building> OnBuildingRemoved
        {
            add => _manager.OnBuildingRemoved += value;
            remove => _manager.OnBuildingRemoved -= value;
        }

        private void Awake()
        {
            _manager = new BuildingManufacturesManager(manufacturesManager);
        }

        public bool TryAddBuildingManufacture(Building building, IManufacture manufacture)
        {
            return _manager.TryAddBuildingManufacture(building, manufacture);
        }

        public bool TryRemoveBuildingManufacture(Building building)
        {
            return _manager.TryRemoveBuildingManufacture(building);
        }

        public bool TryGetBuildingManufacture(Building building, out IManufacture manufacture)
        {
            return _manager.TryGetBuildingManufacture(building, out manufacture);
        }
    }
}