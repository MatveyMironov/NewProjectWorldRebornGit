using UnityEngine;

namespace ProgressionSystem
{
    public abstract class ATaskDisplayerMB : MonoBehaviour, ITaskDisplayer
    {
        public abstract void DisplayTask(ITask task);
        public abstract void Clear();
    }
}