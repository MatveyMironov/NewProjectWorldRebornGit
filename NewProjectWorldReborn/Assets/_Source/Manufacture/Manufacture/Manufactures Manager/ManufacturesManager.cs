using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    public class ManufacturesManager : IManufacturesManager
    {
        private readonly IManufactureStorageConnector _connector;

        public ManufacturesManager(IManufactureStorageConnector connector)
        {
            _connector = connector ?? throw new ArgumentNullException(nameof(connector));
        }

        private readonly HashSet<IManufacture> _manufactures = new();

        public HashSet<IManufacture> Manufactures => new(_manufactures);
        public event Action<IManufacture> OnManufactureAdded;
        public event Action<IManufacture> OnManufactureRemoved;

        public bool TryAddManufacture(IManufacture manufacture)
        {
            if (_manufactures.Add(manufacture))
            {
                _connector.ConnectManufacture(manufacture);
                OnManufactureAdded?.Invoke(manufacture);
                return true;
            }

            return false;
        }

        public bool TryRemoveManufacture(IManufacture manufacture)
        {
            if (_manufactures.Remove(manufacture))
            {
                _connector.DisconnectManufacture(manufacture);
                OnManufactureRemoved?.Invoke(manufacture);
                return true;
            }

            return false;
        }
    }
}