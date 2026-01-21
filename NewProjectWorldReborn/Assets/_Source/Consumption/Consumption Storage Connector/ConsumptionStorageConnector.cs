using ResourceSystem;
using StorageSystem;
using System;

namespace ConsumptionSystem
{
    //Enables consumption to take resource from storage
    public class ConsumptionStorageConnector : IConsumptionStorageConnector
    {
        private readonly IStorage _storage;

        public ConsumptionStorageConnector(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void ConnectConsumption(Consumption consumption)
        {
            consumption.OnResourceConsumptionRequested += ConsumeResource;
        }

        public void DisconnectConsumption(Consumption consumption)
        {
            consumption.OnResourceConsumptionRequested -= ConsumeResource;
        }

        private int ConsumeResource(ResourceDefinitionSO resource, int amount)
        {
            //Trying to remove requested amount from storage
            if (_storage.TryRemoveResource(resource, amount))
            {
                return amount;
            }

            //If failed (because storage does not contain enough resource), trying to remove any stored amount from storage
            int storedAmount = _storage.GetResourceCount(resource);
            if (storedAmount > 0)
            {
                if (_storage.TryRemoveResource(resource, storedAmount))
                {
                    return storedAmount;
                }
            }

            //If failed (because storage does not contain any resource), zero amount is removed
            return 0;
        }
    }
}