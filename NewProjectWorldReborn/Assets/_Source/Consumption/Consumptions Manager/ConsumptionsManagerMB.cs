using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConsumptionSystem
{
    public class ConsumptionsManagerMB : MonoBehaviour, IConsumptionsManager
    {
        [SerializeField] private ConsumptionControllerMB consumptionController;
        [SerializeField] private ConsumptionStorageConnectorMB consumptionStorageConnector;

        private IConsumptionsManager _consumptionsManager;

        private void Awake()
        {
            _consumptionsManager = new ConsumptionsManager(consumptionController, consumptionStorageConnector);
        }

        public HashSet<Consumption> Consumptions => _consumptionsManager.Consumptions;

        public event Action<Consumption> OnConsumptionAdded
        {
            add =>  _consumptionsManager.OnConsumptionAdded += value;
            remove => _consumptionsManager.OnConsumptionAdded -= value;
        }

        public event Action<Consumption> OnConsumptionRemoved
        {
            add => _consumptionsManager.OnConsumptionRemoved += value;
            remove => _consumptionsManager.OnConsumptionRemoved -= value;
        }

        public bool TryAddConsumption(Consumption consumption)
        {
            return _consumptionsManager.TryAddConsumption(consumption);
        }

        public bool TryRemoveConsumption(Consumption consumption)
        {
            return _consumptionsManager.TryRemoveConsumption(consumption);
        }
    }
}