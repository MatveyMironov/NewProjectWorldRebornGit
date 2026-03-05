using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem
{
    public class SingletonManufactureControllerMB : MonoBehaviour
    {
        private readonly HashSet<IManufacture> _manufactures = new();

        private readonly IManufacturesManager _manufacturesManager = ManufacturesManagerSingleton.Instance;

        private void Start()
        {
            _manufacturesManager.OnManufactureAdded += AddManufacture;
            _manufacturesManager.OnManufactureRemoved += RemoveManufacture;

            foreach (var manufacture in _manufacturesManager.Manufactures)
            {
                AddManufacture(manufacture);
            }
        }

        private void OnDestroy()
        {
            _manufacturesManager.OnManufactureAdded -= AddManufacture;
            _manufacturesManager.OnManufactureRemoved -= RemoveManufacture;
        }

        private void Update()
        {
            foreach (var manufacture in _manufactures)
            {
                manufacture.ProgressManufacture();
            }
        }

        public void AddManufacture(IManufacture manufacture)
        {
            if (_manufactures.Add(manufacture))
            {
                Debug.Log($"Manufacture {manufacture} added");
                manufacture.StartManufacture();
            }
        }

        public void RemoveManufacture(IManufacture manufacture)
        {
            if (_manufactures.Remove(manufacture))
            {
                Debug.Log($"Manufacture {manufacture} removed");
                manufacture.AbortManufacture();
            }
        }
    }
}