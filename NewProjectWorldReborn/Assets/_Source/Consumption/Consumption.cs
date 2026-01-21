using ResourceSystem;
using System;
using UnityEngine;

namespace ConsumptionSystem
{
    public class Consumption
    {
        private readonly ConsumptionParameters _parameters;

        public Consumption(ConsumptionParameters parameters)
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public ResourceDefinitionSO ConsumedResource => _parameters.ConsumedResource;
        public int ConsumptionPeriod => _parameters.ConsumptionPeriod;
        public int ConsumedAmount => _parameters.ConsumedAmount;

        public bool IsPaused { get; set; }

        public float ConsumptionProgress { get; private set; }
        public event Action OnConsumptionProgressChanged;

        public event Func<ResourceDefinitionSO, int, int> OnResourceConsumptionRequested;

        public float Satisfaction { get; private set; }
        public event Action OnSatisfactionChanged;

        public void ProgressConsumption()
        {
            if (IsPaused) return;

            ConsumptionProgress += Time.deltaTime / ConsumptionPeriod;
            OnConsumptionProgressChanged?.Invoke();

            if (ConsumptionProgress >= 1.0f) CompleteConsumption();
        }

        private void CompleteConsumption()
        {
            ConsumptionProgress -= 1.0f;
            int actualConsumedAmount = (int)(OnResourceConsumptionRequested?.Invoke(ConsumedResource, ConsumedAmount));
            Satisfaction = (float)actualConsumedAmount / ConsumedAmount;
            OnSatisfactionChanged?.Invoke();
        }
    }
}