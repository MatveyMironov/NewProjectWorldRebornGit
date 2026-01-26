using UnityEngine;

namespace ManufactureSystem
{
    public static class ManufactureControllerSingleton
    {
        private static IManufactureController _instance;
        public static IManufactureController Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameObject = new();
                    _instance = gameObject.AddComponent<ManufactureControllerMB>();
                }

                return _instance;
            }
        }
    }
}