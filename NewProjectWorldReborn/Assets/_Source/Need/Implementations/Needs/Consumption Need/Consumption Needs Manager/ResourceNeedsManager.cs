using ConsumptionSystem;
using System;
using System.Collections.Generic;

namespace NeedSystem.Implementations
{
    public class ResourceNeedsManager : IResourceNeedsManager
    {
        private readonly IConsumptionsManager _consumptionsManager;

        public ResourceNeedsManager(IConsumptionsManager consumptionsManager)
        {
            _consumptionsManager = consumptionsManager ?? throw new ArgumentNullException(nameof(consumptionsManager));
        }

        private readonly Dictionary<ConsumptionNeed, Consumption> _resourceNeedsConsumptions = new();

        public bool TryAddResourceNeedConsumption(ConsumptionNeed need, Consumption consumption)
        {
            if (_resourceNeedsConsumptions.TryAdd(need, consumption))
            {
                _consumptionsManager.TryAddConsumption(consumption);
                return true;
            }

            return false;
        }

        public bool TryRemoveResourceNeedConsumption(ConsumptionNeed need)
        {
            if (_resourceNeedsConsumptions.Remove(need, out Consumption consumption))
            {
                _consumptionsManager.TryRemoveConsumption(consumption);
                return true;
            }

            return false;
        }
    }
}