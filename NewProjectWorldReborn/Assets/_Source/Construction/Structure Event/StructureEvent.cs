using ConstructionGridSystem;
using GameEventSystem;
using UnityEngine;

namespace ConstructionSystem
{
    [CreateAssetMenu(fileName = "New Structure Event", menuName = "Event/Structure")]
    public class StructureEvent : AGameEvent<BuildingStructure> { }
}