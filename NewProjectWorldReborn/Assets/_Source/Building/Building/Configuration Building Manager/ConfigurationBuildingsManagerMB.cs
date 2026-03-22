using System;
using UnityEngine;

namespace BuildingSystem
{
    public class ConfigurationBuildingsManagerMB : MonoBehaviour, IConfigurationBuildingsManager
    {
        private IConfigurationBuildingsManager _manager;

        private void Awake()
        {
            _manager = new ConfigurationBuildingsManager();
        }

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

        public bool TryAddBuilding(Building building)
        {
            return _manager.TryAddBuilding(building);
        }

        public bool TryRemoveBuilding(Building building)
        {
            return _manager.TryRemoveBuilding(building);
        }

        public int GetBuildingCount(IBuildingConfiguration configuration)
        {
            return _manager.GetBuildingCount(configuration);
        }
    }
}