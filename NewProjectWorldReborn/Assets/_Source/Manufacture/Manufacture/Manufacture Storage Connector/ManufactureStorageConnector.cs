using ResourceSystem;
using StorageSystem;
using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    public class ManufactureStorageConnector : IManufactureStorageConnector
    {
        private readonly IStorage _storage;

        public ManufactureStorageConnector(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void ConnectManufacture(IManufacture manufacture)
        {
            manufacture.OnConsumptionRequested += TryTakeResourcesFromStorage;
            manufacture.OnProductionRequested += PutResourcesIntoStorage;
        }

        public void DisconnectManufacture(IManufacture manufacture)
        {
            manufacture.OnConsumptionRequested -= TryTakeResourcesFromStorage;
            manufacture.OnProductionRequested -= PutResourcesIntoStorage;
        }

        private bool TryTakeResourcesFromStorage(Dictionary<IResourceDefinition, int> resources)
        {
            foreach (var resource in resources)
            {
                if (_storage.GetResourceCount(resource.Key) < resource.Value) return false;
            }

            foreach (var resource in resources)
            {
                _storage.TryRemoveResource(resource.Key, resource.Value);
            }

            return true;
        }

        private bool PutResourcesIntoStorage(Dictionary<IResourceDefinition, int> resources)
        {
            foreach (var resource in resources)
            {
                _storage.AddResource(resource.Key, resource.Value);
            }

            return true;
        }
    }
}