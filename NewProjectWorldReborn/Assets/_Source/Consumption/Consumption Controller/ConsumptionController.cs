using System.Collections.Generic;

namespace ConsumptionSystem
{
    public class ConsumptionController : IConsumptionController
    {
        private readonly List<Consumption> _consumptions = new();

        public void AddConsumption(Consumption consumption)
        {
            _consumptions.Add(consumption);
        }

        public void RemoveConsumption(Consumption consumption)
        {
            _consumptions.Remove(consumption);
        }

        public void Update()
        {
            foreach (var consumption in _consumptions)
            {
                consumption.ProgressConsumption();
            }
        }
    }
}