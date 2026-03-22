using UnityEngine;

namespace ResourceSystem
{
    public abstract class AResourceCountDisplayerMB : MonoBehaviour, IResourceCountDisplayer
    {
        public abstract void DisplayResource(IResourceDefinition resource);
        public abstract void DisplayCount(int count);
    }
}