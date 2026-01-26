using UnityEngine;

namespace ManufactureSystem
{
    public abstract class AManufactureDisplayerMB : MonoBehaviour, IManufactureDisplayer
    {
        public abstract void DisplayManufacture(IManufacture manufacture);
        public abstract void Clear();
    }
}