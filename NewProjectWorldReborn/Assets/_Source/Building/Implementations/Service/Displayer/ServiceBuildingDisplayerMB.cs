using ServiceSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class ServiceBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private AServiceProviderDisplayerMB serviceProviderDisplayer;

        public override void DisplayBuilding(Building building)
        {
            ServiceProvider serviceProvider = building.Interior.ServiceProvider;

            if (serviceProvider == null)
            {
                Clear();
                return;
            }

            serviceProviderDisplayer.DisplayServiceProvider(serviceProvider);
        }

        public override void Clear()
        {
            serviceProviderDisplayer.Clear();
        }
    }
}