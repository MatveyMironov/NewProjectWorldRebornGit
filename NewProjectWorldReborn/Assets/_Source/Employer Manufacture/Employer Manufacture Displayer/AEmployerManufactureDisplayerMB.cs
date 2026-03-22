using UnityEngine;

namespace EmployerManufactureSystem
{
    public abstract class AEmployerManufactureDisplayerMB : MonoBehaviour, IEmployerManufactureDisplayer
    {
        public abstract void DisplayEmployerManufacture(EmployerManufacture employerManufacture);
        public abstract void Clear();
    }
}