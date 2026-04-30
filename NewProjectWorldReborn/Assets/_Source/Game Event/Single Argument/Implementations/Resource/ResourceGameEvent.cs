using ResourceSystem;
using UnityEngine;

namespace GameEventSystem.Implementations.Resource
{
    [CreateAssetMenu(fileName = "New Resource Event", menuName = "Event/Resource")]
    public class ResourceGameEvent : AGameEvent<IResourceDefinition> { }
}