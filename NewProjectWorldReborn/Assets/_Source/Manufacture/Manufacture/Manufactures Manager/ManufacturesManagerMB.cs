using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem
{
    public class ManufacturesManagerMB : MonoBehaviour, IManufacturesManager
    {
        [SerializeField] private ManufactureStorageConnectorMB storageConnector;

        private IManufacturesManager _manager;

        private void Awake()
        {
            _manager = new ManufacturesManager(storageConnector);
        }

        public HashSet<IManufacture> Manufactures => _manager.Manufactures;

        public event Action<IManufacture> OnManufactureAdded
        {
            add => _manager.OnManufactureAdded += value;
            remove => _manager.OnManufactureAdded -= value;
        }

        public event Action<IManufacture> OnManufactureRemoved
        {
            add => _manager.OnManufactureRemoved += value;
            remove => _manager.OnManufactureRemoved -= value;
        }

        public bool TryAddManufacture(IManufacture manufacture)
        {
            return _manager.TryAddManufacture(manufacture);
        }

        public bool TryRemoveManufacture(IManufacture manufacture)
        {
            return _manager.TryRemoveManufacture(manufacture);
        }
    }
}