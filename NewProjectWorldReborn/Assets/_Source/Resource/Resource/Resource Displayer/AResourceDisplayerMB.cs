using UnityEngine;

namespace ResourceSystem
{
    public abstract class AResourceDisplayerMB : MonoBehaviour, IResourceDisplayer
    {
        public abstract void DisplayResource(IResourceDefinition resource);
        public abstract void Clear();
    }
}