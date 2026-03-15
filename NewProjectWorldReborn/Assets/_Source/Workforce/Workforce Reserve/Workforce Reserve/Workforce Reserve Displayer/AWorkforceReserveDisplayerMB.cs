using UnityEngine;

namespace WorkforceReserveSystem
{
    public abstract class AWorkforceReserveDisplayerMB : MonoBehaviour, IWorkforceReserveDisplayer
    {
        public abstract void DisplayReserve(IWorkforceReserve workforceReserve);
        public abstract void Clear();
    }
}