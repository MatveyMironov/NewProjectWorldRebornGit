using UnityEngine;

namespace ServiceSystem.Implementations
{
    public abstract class AServiceProvidersManagerDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private AServiceProvidersManagerDisplayer displayer;
        protected abstract IServiceProvidersManager Manager { get; }

        protected virtual void Start()
        {
            displayer.DisplayServiceProvidersManager(Manager);
        }
    }
}