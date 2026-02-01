using UnityEngine;

namespace ResourceSystem
{
    public interface IResourceDefinition
    {
        string Name { get; }
        string Description { get; }
        Sprite Icon { get; }
    }
}