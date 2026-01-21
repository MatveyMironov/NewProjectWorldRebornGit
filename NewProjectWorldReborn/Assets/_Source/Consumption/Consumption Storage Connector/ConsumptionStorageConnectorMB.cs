using StorageSystem;
using UnityEngine;

namespace ConsumptionSystem
{
    public class ConsumptionStorageConnectorMB : MonoBehaviour, IConsumptionStorageConnector
    {
        [SerializeField] private StorageMB storage;

        private IConsumptionStorageConnector _connector;

        private void Awake()
        {
            _connector = new ConsumptionStorageConnector(storage);
        }

        public void ConnectConsumption(Consumption consumption)
        {
            _connector.ConnectConsumption(consumption);
        }

        public void DisconnectConsumption(Consumption consumption)
        {
            _connector.DisconnectConsumption(consumption);
        }
    }
}