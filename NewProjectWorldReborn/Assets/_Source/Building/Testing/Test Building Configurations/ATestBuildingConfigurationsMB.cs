using UnityEngine;

namespace BuildingSystem.Testing
{
    public abstract class ATestBuildingConfigurationsMB : MonoBehaviour
    {
        [SerializeField] private BuildingConfigurationSO[] buildingConfigurations = new BuildingConfigurationSO[0];

        protected abstract IBuildingConfigurationsManager BuildingConfigurationsManager { get; }

        protected virtual void Start()
        {
            foreach (var configuration in buildingConfigurations)
            {
                BuildingConfigurationsManager.TryAddConfiguration(configuration);
            }
        }
    }
}