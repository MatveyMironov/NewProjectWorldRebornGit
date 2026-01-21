using ResourceSystem;
using System;

namespace ConsumptionSystem
{
    public class ConsumptionParameters
    {
        public ResourceDefinitionSO ConsumedResource { get; }
        public int ConsumedAmount { get; }
        public int ConsumptionPeriod { get; }

        public ConsumptionParameters(ResourceDefinitionSO consumedResource, int consumedAmount, int consumptionTime)
        {
            ConsumedResource = consumedResource != null ? consumedResource : throw new ArgumentNullException(nameof(consumedResource));
            ConsumedAmount = consumedAmount > 0 ? consumedAmount : throw new ArgumentOutOfRangeException(nameof(consumedAmount));
            ConsumptionPeriod = consumptionTime > 0 ? consumptionTime : throw new ArgumentOutOfRangeException(nameof(consumptionTime));
        }
    }
}