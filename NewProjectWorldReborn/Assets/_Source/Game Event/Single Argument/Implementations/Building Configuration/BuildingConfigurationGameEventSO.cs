using BuildingSystem;
using UnityEngine;

namespace GameEventSystem.Implementations.BuildingConfiguration
{
    [CreateAssetMenu(fileName = "New Building Configuration Game Event", menuName = "Game Event/Building Configuration")]
    public class BuildingConfigurationGameEventSO : AGameEventSO<IBuildingConfiguration> { }
}