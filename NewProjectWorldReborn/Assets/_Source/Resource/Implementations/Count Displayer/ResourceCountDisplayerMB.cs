using CustomUISystem;
using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class ResourceCountDisplayerMB : AResourceCountDisplayerMB
    {
        [SerializeField] private AResourceDisplayerMB resourceDisplayer;
        [SerializeField] private ANumberDisplayerMB countDisplayer;

        public override void DisplayResource(IResourceDefinition resource)
        {
            resourceDisplayer.DisplayResource(resource);
        }

        public override void DisplayCount(int count)
        {
            countDisplayer.DisplayNumber(count);
        }
    }
}