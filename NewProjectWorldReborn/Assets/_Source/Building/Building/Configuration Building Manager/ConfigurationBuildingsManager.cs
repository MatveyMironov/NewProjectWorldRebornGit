using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public class ConfigurationBuildingsManager : IConfigurationBuildingsManager
    {
        private readonly Dictionary<IBuildingConfiguration, HashSet<Building>> _configurations_Buildings = new();

        public event Action<Building> OnBuildingAdded;
        public event Action<Building> OnBuildingRemoved;

        public bool TryAddBuilding(Building building)
        {
            if (_configurations_Buildings.TryAdd(building.Configuration, new()))
            {
                //Debug.Log($"Building was added from new configuration {building.Configuration}");
            }

            if (_configurations_Buildings[building.Configuration].Add(building))
            {
                //Debug.Log($"Building {building} from configuration {building.Configuration} was added");
                OnBuildingAdded?.Invoke(building);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuilding(Building building)
        {
            if (_configurations_Buildings.TryGetValue(building.Configuration, out var buildings)
                && buildings.Remove(building))
            {
                //Debug.Log($"Building {building} from configuration {building.Configuration} was removed");
                OnBuildingRemoved?.Invoke(building);
                return true;
            }

            return false;
        }

        public int GetBuildingCount(IBuildingConfiguration configuration)
        {
            if (_configurations_Buildings.TryGetValue(configuration, out var buildings))
            {
                return buildings.Count;
            }

            return 0;
        }
    }
}