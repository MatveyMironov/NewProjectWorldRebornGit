using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Empty Task", menuName = "Progression/Task Configuration/Empty Task")]
    public class EmptyTaskConfigurationSO : ATaskConfigurationSO
    {
        public override ITask CreateTask()
        {
            return new EmptyTask();
        }
    }
}