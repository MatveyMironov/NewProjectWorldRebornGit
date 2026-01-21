using ConsumptionSystem;
using System;

namespace NeedSystem.Implementations
{
    public class ConsumptionNeed : INeed
    {
        private readonly Consumption _consumption;

        public ConsumptionNeed(Consumption consumption)
        {
            _consumption = consumption ?? throw new ArgumentNullException(nameof(consumption));
        }

        public string Name => _consumption.ConsumedResource.Name;

        public float Satisfaction => _consumption.Satisfaction;
        public event Action OnSatisfactionChanged
        {
            add => _consumption.OnSatisfactionChanged += value;
            remove => _consumption.OnSatisfactionChanged -= value;
        }
    }
}