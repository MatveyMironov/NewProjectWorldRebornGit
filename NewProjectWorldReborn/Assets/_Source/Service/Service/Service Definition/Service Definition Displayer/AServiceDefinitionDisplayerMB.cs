using UnityEngine;

namespace ServiceSystem
{
    public abstract class AServiceDefinitionDisplayerMB : MonoBehaviour, IServiceDefinitionDisplayer
    {
        public abstract void DisplayServiceDefinition(IServiceDefinition service);
        public abstract void Clear();
    }
}