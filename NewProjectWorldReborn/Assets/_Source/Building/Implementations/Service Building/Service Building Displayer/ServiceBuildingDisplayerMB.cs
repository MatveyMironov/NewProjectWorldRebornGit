using ServiceSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class ServiceBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private AServiceProviderDisplayerMB serviceProviderDisplayer;

        private readonly IServiceBuildingsManager _serviceBuildingsManager = ServiceBuildingsManagerSingleton.Instance;

        public override void DisplayBuilding(Building building)
        {
            if (_serviceBuildingsManager.TryGetBuildingServiceProvider(building, out ServiceProvider serviceProvider))
            {
                serviceProviderDisplayer.DisplayServiceProvider(serviceProvider);
            }
        }

        public override void Clear()
        {
            serviceProviderDisplayer.Clear();
        }
    }
}