using UnityEngine;

namespace ProgressionSystem
{
    public abstract class ATaskDisplayersManagerMB : MonoBehaviour, ITaskDisplayersManager
    {
        public abstract bool TryAddTaskDisplayer(ITask task);
        public abstract bool TryRemoveTaskDisplayer(ITask task);
    }
}