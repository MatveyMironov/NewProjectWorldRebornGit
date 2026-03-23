using GameEventSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Quest Chain Event", menuName = "Event/Quest Chain")]
    public class QuestChainEvent : AGameEvent<QuestChain> { }
}