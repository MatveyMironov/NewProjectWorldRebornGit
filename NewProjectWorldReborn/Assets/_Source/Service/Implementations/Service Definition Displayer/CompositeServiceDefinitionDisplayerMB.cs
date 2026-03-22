using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class CompositeServiceDefinitionDisplayerMB : AServiceDefinitionDisplayerMB
    {
        [SerializeField] private AServiceDefinitionDisplayerMB[] displayers = new AServiceDefinitionDisplayerMB[0];

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            foreach (var displayer in displayers)
            {
                displayer.DisplayServiceDefinition(service);
            }
        }

        public override void Clear()
        {
            foreach (var displayer in displayers)
            {
                displayer.Clear();
            }
        }
    }
}