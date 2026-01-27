using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class ABuildingConfiguratinsManagerDisplayerSetuper : MonoBehaviour
    {
        [SerializeField] private ABuildingConfigurationsManagerDisplayerMB buildingConfigurationsManagerDisplayer;

        protected abstract IBuildingConfigurationsManager BuildingConfigurationsManager { get; }

        protected virtual void Start()
        {
            buildingConfigurationsManagerDisplayer.DisplayBuildingConfigurationsManager(BuildingConfigurationsManager);
        }
    }
}