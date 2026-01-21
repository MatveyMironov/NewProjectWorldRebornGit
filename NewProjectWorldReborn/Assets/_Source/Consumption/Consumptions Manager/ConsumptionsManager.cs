using System;
using System.Collections.Generic;

namespace ConsumptionSystem
{
    public class ConsumptionsManager : IConsumptionsManager
    {
        private readonly IConsumptionController _consumptionController;
        private readonly IConsumptionStorageConnector _consumptionStorageConnector;

        public ConsumptionsManager(IConsumptionController consumptionController, IConsumptionStorageConnector consumptionStorageConnector)
        {
            _consumptionController = consumptionController ?? throw new ArgumentNullException(nameof(consumptionController));
            _consumptionStorageConnector = consumptionStorageConnector ?? throw new ArgumentNullException(nameof(consumptionStorageConnector));
        }

        private readonly HashSet<Consumption> _consumptions = new();

        public HashSet<Consumption> Consumptions => new(_consumptions);
        public event Action<Consumption> OnConsumptionAdded;
        public event Action<Consumption> OnConsumptionRemoved;

        public bool TryAddConsumption(Consumption consumption)
        {
            if (_consumptions.Add(consumption))
            {
                _consumptionController.AddConsumption(consumption);
                _consumptionStorageConnector.ConnectConsumption(consumption);
                OnConsumptionAdded?.Invoke(consumption);
                return true;
            }

            return false;
        }

        public bool TryRemoveConsumption(Consumption consumption)
        {
            if (_consumptions.Remove(consumption))
            {
                _consumptionController.RemoveConsumption(consumption);
                _consumptionStorageConnector.DisconnectConsumption(consumption);
                OnConsumptionRemoved?.Invoke(consumption);
                return true;
            }

            return false;
        }
    }
}