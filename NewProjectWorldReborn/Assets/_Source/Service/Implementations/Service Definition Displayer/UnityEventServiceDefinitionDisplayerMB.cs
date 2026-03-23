using UnityEngine;
using UnityEngine.Events;

namespace ServiceSystem.Implementations
{
    public class UnityEventServiceDefinitionDisplayerMB : AServiceDefinitionDisplayerMB
    {
        [SerializeField] private UnityEvent<IServiceDefinition> displayServiceDefinition;
        [SerializeField] private UnityEvent clear;

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            displayServiceDefinition.Invoke(service);
        }

        public override void Clear()
        {
            clear.Invoke();
        }
    }
}