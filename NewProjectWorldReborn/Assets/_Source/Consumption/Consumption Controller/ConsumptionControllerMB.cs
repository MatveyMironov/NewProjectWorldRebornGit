using UnityEngine;

namespace ConsumptionSystem
{
    public class ConsumptionControllerMB : MonoBehaviour, IConsumptionController
    {
        private IConsumptionController _consumptionController;

        private void Awake()
        {
            _consumptionController = new ConsumptionController();
        }

        public void Update()
        {
            _consumptionController.Update();
        }

        public void AddConsumption(Consumption consumption)
        {
            _consumptionController.AddConsumption(consumption);
        }

        public void RemoveConsumption(Consumption consumption)
        {
            _consumptionController.RemoveConsumption(consumption);
        }
    }
}