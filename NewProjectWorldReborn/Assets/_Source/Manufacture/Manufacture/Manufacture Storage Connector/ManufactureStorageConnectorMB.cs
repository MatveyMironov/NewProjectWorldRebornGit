using StorageSystem;
using UnityEngine;

namespace ManufactureSystem
{
    public class ManufactureStorageConnectorMB : MonoBehaviour, IManufactureStorageConnector
    {
        [SerializeField] private StorageMB storage;

        private IManufactureStorageConnector _connector;

        private void Awake()
        {
            _connector = new ManufactureStorageConnector(storage);
        }

        public void ConnectManufacture(IManufacture manufacture)
        {
            _connector.ConnectManufacture(manufacture);
        }

        public void DisconnectManufacture(IManufacture manufacture)
        {
            _connector.DisconnectManufacture(manufacture);
        }
    }
}