using UnityEngine;

namespace ServiceSystem
{
    public abstract class AServiceBalanceDisplayerMB : MonoBehaviour, IServiceBalanceDisplayer
    {
        public abstract void DisplayServiceBalance(IServiceDefinition service);
        public abstract void Clear();
    }
}