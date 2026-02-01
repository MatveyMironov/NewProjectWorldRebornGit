using UnityEngine;

namespace BuildingSystem.Testing
{
    public abstract class ATestBuildingConfigurationsMB : MonoBehaviour
    {
        [SerializeField] private ABuildingConfigurationSO[] buildingConfigurations = new ABuildingConfigurationSO[0];

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