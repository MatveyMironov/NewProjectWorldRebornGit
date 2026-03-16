using System;

namespace ResourceSystem.Implementations
{
    public class StaticEventResourceDisplayerMB : AResourceDisplayerMB
    {
        public static event Action<IResourceDefinition> OnResourceDisplayed;
        public static event Action OnCleared;

        public override void DisplayResource(IResourceDefinition resource)
        {
            OnResourceDisplayed?.Invoke(resource);
        }

        public override void Clear()
        {
            OnCleared?.Invoke();
        }
    }
}