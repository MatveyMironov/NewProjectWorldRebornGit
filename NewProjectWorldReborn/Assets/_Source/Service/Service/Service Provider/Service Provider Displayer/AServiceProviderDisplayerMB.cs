using UnityEngine;

namespace ServiceSystem
{
    public abstract class AServiceProviderDisplayerMB : MonoBehaviour, IServiceProviderDisplayer
    {
        public abstract void DisplayServiceProvider(ServiceProvider serviceProvider);
        public abstract void Clear();
    }
}