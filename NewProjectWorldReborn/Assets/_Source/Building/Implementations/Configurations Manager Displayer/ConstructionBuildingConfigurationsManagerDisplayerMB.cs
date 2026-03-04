using UnityEngine;

namespace BuildingSystem
{
    public class ConstructionBuildingConfigurationsManagerDisplayerMB : ABuildingConfigurationsManagerDisplayerMB
    {
        [SerializeField] private ABuildingConstructionsManagerMB buildingConstructionsManager;

        private IBuildingConfigurationsManager _displayedManager;

        private void OnDestroy()
        {
            Clear();
        }

        public override void DisplayBuildingConfigurationsManager(IBuildingConfigurationsManager manager)
        {
            Clear();

            _displayedManager = manager;

            foreach (var configuration in manager.BuildingConfigurations)
            {
                AddBuildingConstruction(configuration);
            }

            manager.OnBuildingConfigurationAdded += AddBuildingConstruction;
            manager.OnBuildingConfigurationRemoved += RemoveBuildingConstruction;
        }

        public override void Clear()
        {
            if (_displayedManager == null) return;

            _displayedManager.OnBuildingConfigurationAdded -= AddBuildingConstruction;
            _displayedManager.OnBuildingConfigurationRemoved -= RemoveBuildingConstruction;

            foreach (var configuration in _displayedManager.BuildingConfigurations)
            {
                RemoveBuildingConstruction(configuration);
            }

            _displayedManager = null;
        }

        private void AddBuildingConstruction(IBuildingConfiguration configuration)
        {
            buildingConstructionsManager.TryAddBuildingConstruction(configuration);
        }

        private void RemoveBuildingConstruction(IBuildingConfiguration configuration)
        {
            buildingConstructionsManager.TryRemoveBuildingConstruction(configuration);
        }
    }
}