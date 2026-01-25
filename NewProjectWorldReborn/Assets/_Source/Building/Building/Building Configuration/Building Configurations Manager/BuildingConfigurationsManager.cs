using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSystem
{
    public class BuildingConfigurationsManager : IBuildingConfigurationsManager
    {
        private readonly HashSet<IBuildingConfiguration> _buildingConfigurations = new();

        public IBuildingConfiguration[] BuildingConfigurations => _buildingConfigurations.ToArray();
        public event Action<IBuildingConfiguration> OnBuildingConfigurationAdded;
        public event Action<IBuildingConfiguration> OnBuildingConfigurationRemoved;

        public bool TryAddConfiguration(IBuildingConfiguration configuration)
        {
            if (_buildingConfigurations.Add(configuration))
            {
                OnBuildingConfigurationAdded?.Invoke(configuration);
                return true;
            }

            return false;
        }

        public bool TryRemoveConfiguration(IBuildingConfiguration configuration)
        {
            if (_buildingConfigurations.Add(configuration))
            {
                OnBuildingConfigurationRemoved?.Invoke(configuration);
                return true;
            }

            return false;
        }
    }
}