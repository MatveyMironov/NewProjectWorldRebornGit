using UnityEngine;

namespace ServiceSystem
{
    public abstract class AServiceProvidersManagerDisplayer : MonoBehaviour, IServiceProvidersManagerDisplayer
    {
        public abstract void Clear();
        public abstract void DisplayServiceProvidersManager(IServiceProvidersManager manager);
    }
}