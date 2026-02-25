using UnityEngine;

namespace ServiceSystem
{
    [CreateAssetMenu(fileName = "New Service", menuName = "Economy/Service Definition")]
    public class ServiceDefinitionSO : ScriptableObject, IServiceDefinition
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string ServiceDescription { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}