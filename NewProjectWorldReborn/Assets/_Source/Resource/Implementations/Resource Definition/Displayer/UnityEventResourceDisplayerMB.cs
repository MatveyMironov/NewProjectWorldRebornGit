using UnityEngine;
using UnityEngine.Events;

namespace ResourceSystem.Implementations
{
    public class UnityEventResourceDisplayerMB : AResourceDisplayerMB
    {
        [SerializeField] private UnityEvent<IResourceDefinition> DisplayResourceEvent;
        [SerializeField] private UnityEvent ClearEvent;

        public override void DisplayResource(IResourceDefinition resource)
        {
            DisplayResourceEvent.Invoke(resource);
        }

        public override void Clear()
        {
            ClearEvent.Invoke();
        }
    }
}