using UnityEngine;

namespace ManufactureSystem
{
    public abstract class AManufacturesManagerDisplayerMB : MonoBehaviour, IManufacturesManagerDisplayer
    {
        public abstract void DisplayManufacturesManager(IManufacturesManager manufacturesManager);
        public abstract void Clear();
    }
}