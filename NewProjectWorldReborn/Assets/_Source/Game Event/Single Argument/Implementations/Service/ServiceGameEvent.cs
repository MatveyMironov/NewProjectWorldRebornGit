using ServiceSystem;
using UnityEngine;

namespace GameEventSystem.Implementations.Service
{
    [CreateAssetMenu(fileName = "New Service Event", menuName = "Event/Service")]
    public class ServiceGameEvent : AGameEvent<IServiceDefinition> { }
}