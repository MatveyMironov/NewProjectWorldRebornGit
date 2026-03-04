using UnityEngine;

namespace ManufactureSystem
{
    public class ManufactureControllerMB : MonoBehaviour, IManufactureController
    {
        private IManufactureController _manufactureController;

        private void Awake()
        {
            _manufactureController = new ManufactureController();
        }

        public void Update()
        {
            _manufactureController.Update();
        }

        public bool TryAddManufacture(IManufacture manufacture)
        {
            return _manufactureController.TryAddManufacture(manufacture);
        }

        public bool TryRemoveManufacture(IManufacture manufacture)
        {
            return _manufactureController.TryRemoveManufacture(manufacture);
        }
    }
}