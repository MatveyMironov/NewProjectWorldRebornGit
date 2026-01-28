using UnityEngine;

namespace ProgressionSystem
{
    public abstract class ATaskConfigurationSO : ScriptableObject, ITaskConfiguration
    {
        public abstract ITask CreateTask();
    }
}