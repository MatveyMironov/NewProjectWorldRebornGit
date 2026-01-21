using System;
using System.Collections.Generic;

namespace ConsumptionSystem
{
    public interface IConsumptionsManager
    {
        HashSet<Consumption> Consumptions { get; }
        public event Action<Consumption> OnConsumptionAdded;
        public event Action<Consumption> OnConsumptionRemoved;

        bool TryAddConsumption(Consumption consumption);
        bool TryRemoveConsumption(Consumption consumption);
    }
}