using UnityEngine;

namespace ResourceSystem
{
    public abstract class AResourceCountDisplayersManager : MonoBehaviour, IResourceCountDisplayersManager
    {
        public abstract void DisplayResourceCount(IResourceDefinition resource, int count);
        public abstract void Clear();
    }
}