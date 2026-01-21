using UnityEngine;

namespace ServiceSystem
{
    public interface IServiceDefinition
    {
        string Name { get; }
        string ServiceDescription { get; }
        Sprite Icon { get; }
    }
}