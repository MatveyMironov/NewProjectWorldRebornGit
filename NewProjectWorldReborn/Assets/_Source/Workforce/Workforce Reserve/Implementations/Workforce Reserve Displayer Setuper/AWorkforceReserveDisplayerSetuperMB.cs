using UnityEngine;

namespace WorkforceReserveSystem.Implementations
{
    public abstract class AWorkforceReserveDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private WorkforceReserveDisplayerMB displayer;

        protected abstract IWorkforceReserve Reserve { get; }

        protected virtual void Start()
        {
            displayer.DisplayReserve(Reserve);
        }
    }
}