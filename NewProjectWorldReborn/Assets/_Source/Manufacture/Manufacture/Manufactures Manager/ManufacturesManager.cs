using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    public class ManufacturesManager : IManufacturesManager
    {
        private readonly IManufactureController _controller;
        private readonly IManufactureStorageConnector _connector;

        public ManufacturesManager(IManufactureController controller, IManufactureStorageConnector connector)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
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
                _controller.TryAddManufacture(manufacture);
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
                _controller.TryRemoveManufacture(manufacture);
                _connector.DisconnectManufacture(manufacture);
                OnManufactureRemoved?.Invoke(manufacture);
                return true;
            }

            return false;
        }
    }
}