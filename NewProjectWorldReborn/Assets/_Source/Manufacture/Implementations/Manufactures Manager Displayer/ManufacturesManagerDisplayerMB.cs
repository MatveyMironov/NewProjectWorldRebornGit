using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public class ManufacturesManagerDisplayerMB : AManufacturesManagerDisplayerMB
    {
        [SerializeField] private AManufactureDisplayerMB manufactureDisplayerPrefab;
        [SerializeField] private Transform manufactureDisplayersParent;

        private readonly Dictionary<IManufacture, AManufactureDisplayerMB> _manufactureDisplayers = new();

        private IManufacturesManager _displayedManufacturesManager;

        public override void DisplayManufacturesManager(IManufacturesManager manufacturesManager)
        {
            Clear();

            manufacturesManager.OnManufactureAdded += AddManufactureDisplayer;
            manufacturesManager.OnManufactureRemoved += RemoveManufactureDisplayer;

            foreach (var manufacture in manufacturesManager.Manufactures)
            {
                AddManufactureDisplayer(manufacture);
            }

            _displayedManufacturesManager = manufacturesManager;
        }

        public override void Clear()
        {
            if (_displayedManufacturesManager == null) return;

            _displayedManufacturesManager.OnManufactureAdded -= AddManufactureDisplayer;
            _displayedManufacturesManager.OnManufactureRemoved -= RemoveManufactureDisplayer;

            foreach (var manufactureDisplayer in _manufactureDisplayers)
            {
                Destroy(manufactureDisplayer.Value);
            }

            _manufactureDisplayers.Clear();

            _displayedManufacturesManager = null;
        }

        private void AddManufactureDisplayer(IManufacture manufacture)
        {
            if (_manufactureDisplayers.TryAdd(manufacture, null))
            {
                _manufactureDisplayers[manufacture] = Instantiate(manufactureDisplayerPrefab, manufactureDisplayersParent);
                _manufactureDisplayers[manufacture].DisplayManufacture(manufacture);
            }
        }

        private void RemoveManufactureDisplayer(IManufacture manufacture)
        {
            if (_manufactureDisplayers.TryGetValue(manufacture, out var displayer))
            {
                Destroy(displayer);
            }
        }
    }
}