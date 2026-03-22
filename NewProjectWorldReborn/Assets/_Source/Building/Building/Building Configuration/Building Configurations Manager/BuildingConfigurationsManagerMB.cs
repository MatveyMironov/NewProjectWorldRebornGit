using System;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingConfigurationsManagerMB : MonoBehaviour, IBuildingConfigurationsManager
    {
        private IBuildingConfigurationsManager _manager;

        protected virtual void Awake()
        {
            _manager = new BuildingConfigurationsManager();
        }

        public IBuildingConfiguration[] BuildingConfigurations => _manager.BuildingConfigurations;

        public event Action<IBuildingConfiguration> OnBuildingConfigurationAdded
        {
            add => _manager.OnBuildingConfigurationAdded += value;
            remove => _manager.OnBuildingConfigurationAdded -= value;
        }

        public event Action<IBuildingConfiguration> OnBuildingConfigurationRemoved
        {
            add => _manager.OnBuildingConfigurationRemoved += value;
            remove => _manager.OnBuildingConfigurationRemoved -= value;
        }

        public bool TryAddConfiguration(IBuildingConfiguration configuration)
        {
            return _manager.TryAddConfiguration(configuration);
        }

        public bool TryRemoveConfiguration(IBuildingConfiguration configuration)
        {
            return _manager.TryRemoveConfiguration(configuration);
        }
    }
}