using UnityEngine;

namespace ConsumptionSystem
{
    public static class ConsumptionControllerSingleton
    {
        private static IConsumptionController _instance;
        public static IConsumptionController Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameObject = new();
                    _instance = gameObject.AddComponent<ConsumptionControllerMB>();
                }

                return _instance;
            }
        }
    }
}