using GameEventSystem;
using UnityEngine;

namespace ServiceSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Service Event", menuName = "Event/Service")]
    public class ServiceEvent : AGameEvent<IServiceDefinition> { }
}