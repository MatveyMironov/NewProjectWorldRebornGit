using ServiceSystem;
using System;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Service Building", menuName = "Building Configuration/Service Building")]
    public class ServiceBuildingConfigurationSO : ABuildingConfigurationSO
    {
        [Space]
        [SerializeField] private ServiceDefinitionSO providedService;
        [SerializeField] private int providedAmount;

        public static event Action<Building, ServiceProvider> OnServiceBuildingCreated;

        public override Building CreateBuilding()
        {
            Building building = new(this, Construction.CreateBuildingStructure(), Info);
            ServiceProvider serviceProvider = new(providedService, providedAmount);
            OnServiceBuildingCreated?.Invoke(building, serviceProvider);
            return building;
        }
    }
}