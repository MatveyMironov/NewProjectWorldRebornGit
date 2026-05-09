using ConstructionGridSystem;
using UnityEngine;

namespace GameEventSystem.Implementations.Structure
{
    [CreateAssetMenu(fileName = "New Structure Event", menuName = "Event/Structure")]
    public class StructureGameEventSO : AGameEventSO<BuildingStructure> { }
}