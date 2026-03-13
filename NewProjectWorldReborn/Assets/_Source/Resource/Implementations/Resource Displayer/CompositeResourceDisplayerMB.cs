using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class CompositeResourceDisplayerMB : AResourceDisplayerMB
    {
        [SerializeField] private AResourceDisplayerMB[] resourceDisplayers = new AResourceDisplayerMB[0];

        public override void DisplayResource(IResourceDefinition resource)
        {
            foreach (var displayer in resourceDisplayers)
            {
                displayer.DisplayResource(resource);
            }
        }

        public override void Clear()
        {
            foreach (var displayer in resourceDisplayers)
            {
                displayer.Clear();
            }
        }
    }
}