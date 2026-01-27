using UnityEngine;

namespace BuildingSystem
{
    public class BuildingConstructionsManagerSetuperMB : MonoBehaviour
    {
        [SerializeField] private ABuildingConstructionsManagerMB _buildingConstructionActionsManager;

        private IBuildingConfigurationsManager _buildingConfigurationsManager;

        private void OnEnable()
        {
            _buildingConfigurationsManager = BuildingConfigurationsManagerSingleton.Instance;
            _buildingConfigurationsManager.OnBuildingConfigurationAdded += AddBuildingConstructionAction;
            _buildingConfigurationsManager.OnBuildingConfigurationRemoved += RemoveBuildingConstructionAction;
        }

        private void OnDisable()
        {
            _buildingConfigurationsManager.OnBuildingConfigurationAdded -= AddBuildingConstructionAction;
            _buildingConfigurationsManager.OnBuildingConfigurationRemoved -= RemoveBuildingConstructionAction;
        }

        private void AddBuildingConstructionAction(IBuildingConfiguration configuration)
        {
            _buildingConstructionActionsManager.TryAddBuildingConstruction(configuration);
        }

        private void RemoveBuildingConstructionAction(IBuildingConfiguration configuration)
        {
            _buildingConstructionActionsManager.TryRemoveBuildingConstruction(configuration);
        }
    }
}