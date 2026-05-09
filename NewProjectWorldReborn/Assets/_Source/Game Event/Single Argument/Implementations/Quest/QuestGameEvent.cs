using ProgressionSystem;
using UnityEngine;

namespace GameEventSystem.Implementations.ProgressionQuest
{
    [CreateAssetMenu(fileName = "New Quest Event", menuName = "Event/Quest")]
    public class QuestGameEvent : AGameEvent<Quest> { }
}