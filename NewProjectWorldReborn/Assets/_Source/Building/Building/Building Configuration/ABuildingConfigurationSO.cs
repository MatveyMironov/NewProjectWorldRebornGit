using BuildingInfoSystem;
using ConstructionConfigurationSystem;
using ConstructionGridSystem;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingConfigurationSO : ScriptableObject, IBuildingConfiguration
    {
        [SerializeField] private SBuildingInfo info;
        [SerializeField] private SConstructionConfiguration construction;

        public IBuildingInfo Info { get => info; }
        public IConstructionConfiguration Construction { get => construction; }

        public abstract Building CreateBuilding(ConstructedBuilding structure);
    }
}