using GameEventSystem;
using UnityEngine;

namespace ResourceSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Resource Event", menuName = "Event/Resource")]
    public class ResourceEvent : AGameEvent<IResourceDefinition> { }
}