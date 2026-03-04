using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class ABuildingConfiguratinsManagerDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private ABuildingConfigurationsManagerDisplayerMB buildingConfigurationsManagerDisplayer;

        protected abstract IBuildingConfigurationsManager BuildingConfigurationsManager { get; }

        protected virtual void Start()
        {
            buildingConfigurationsManagerDisplayer.DisplayBuildingConfigurationsManager(BuildingConfigurationsManager);
            Debug.Log("Building Configuratins Manager Displayer is setup.");
        }
    }
}