using UnityEngine;
using UnityEngine.Events;

namespace BuildingSystem.Implementations
{
    public class UnityEventBuildingConfigurationDisplayerMB : ABuildingConfigurationDisplayerMB
    {
        [SerializeField] private UnityEvent<IBuildingConfiguration> OnDisplayBuildingConfiguration;
        [SerializeField] private UnityEvent OnClear;

        public override void Clear()
        {
            OnClear.Invoke();
        }

        public override void DisplayBuildingConiguration(IBuildingConfiguration configuration)
        {
            OnDisplayBuildingConfiguration.Invoke(configuration);
        }
    }
}