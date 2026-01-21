using ResourceSystem;
using System;
using UnityEngine;

namespace ConsumptionSystem
{
    [Serializable]
    public class SConsumptionConfiguration : IConsumptionConfiguration
    {
        [SerializeField] ResourceDefinitionSO consumedResource;
        [SerializeField] private int consumedAmount;
        [SerializeField] private int consumptionPeriod;

        public Consumption CreateConsumption()
        {
            ConsumptionParameters parameters = new(consumedResource, consumedAmount, consumptionPeriod);
            return new(parameters);
        }
    }
}
