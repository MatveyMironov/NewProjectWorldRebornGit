using UnityEngine;

namespace BuildingSystem
{
    public class ConstructionBuildingConfigurationsManagerDisplayerMB : ABuildingConfigurationsManagerDisplayerMB
    {
        [SerializeField] private ABuildingConstructionsManagerMB _buildingConstructionActionsManager;

        private IBuildingConfigurationsManager _displayedManager;

        private void OnDestroy()
        {
            Clear();
        }

        public override void DisplayBuildingConfigurationsManager(IBuildingConfigurationsManager manager)
        {
            Clear();

            manager.OnBuildingConfigurationAdded += AddBuildingConstruction;
            manager.OnBuildingConfigurationRemoved += RemoveBuildingConstruction;

            _displayedManager = manager;
        }

        public override void Clear()
        {
            if (_displayedManager == null) return;

            _displayedManager.OnBuildingConfigurationAdded -= AddBuildingConstruction;
            _displayedManager.OnBuildingConfigurationRemoved -= RemoveBuildingConstruction;

            _displayedManager = null;
        }

        private void AddBuildingConstruction(IBuildingConfiguration configuration)
        {
            _buildingConstructionActionsManager.TryAddBuildingConstruction(configuration);
        }

        private void RemoveBuildingConstruction(IBuildingConfiguration configuration)
        {
            _buildingConstructionActionsManager.TryRemoveBuildingConstruction(configuration);
        }
    }
}