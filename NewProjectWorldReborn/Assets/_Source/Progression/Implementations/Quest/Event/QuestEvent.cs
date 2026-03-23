using GameEventSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Quest Event", menuName = "Event/Quest")]
    public class QuestEvent : AGameEvent<Quest> { }
}