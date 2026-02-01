using System;
using UnityEngine;

namespace BuildingInfoSystem
{
    [Serializable]
    public class SBuildingInfo : IBuildingInfo
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
    }
}