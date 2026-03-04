using UnityEngine;

namespace EmployerSystem
{
    public abstract class AEmployerDisplayerMB : MonoBehaviour, IEmployerDisplayer
    {
        public abstract void DisplayEmployer(IEmployer employer);
        public abstract void Clear();
    }
}