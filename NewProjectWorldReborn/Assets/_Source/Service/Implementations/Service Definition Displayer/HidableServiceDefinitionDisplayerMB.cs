using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class HidableServiceDefinitionDisplayerMB : AServiceDefinitionDisplayerMB
    {
        [SerializeField] private AServiceDefinitionDisplayerMB actualDisplayer;

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            actualDisplayer.DisplayServiceDefinition(service);
            gameObject.SetActive(true);
        }

        public override void Clear()
        {
            actualDisplayer.Clear();
            gameObject.SetActive(false);
        }
    }
}