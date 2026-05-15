using ResourceSystem;
using UnityEngine;

namespace GameEventSystem.Implementations.Resource
{
    [CreateAssetMenu(fileName = "New Resource Event", menuName = "Game Event/Resource")]
    public class ResourceGameEventSO : AGameEventSO<IResourceDefinition> { }
}