using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class CompositeTaskDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ATaskDisplayersManagerMB partDisplayersManager;

        private CompositeTask _displayedTask;

        public void DisplayCompositeTask(CompositeTask task)
        {
            Clear();

            foreach (var part in task.Parts)
            {
                partDisplayersManager.TryAddTaskDisplayer(part);
            }

            _displayedTask = task;
        }

        public void Clear()
        {
            if (_displayedTask == null) return;

            foreach (var part in _displayedTask.Parts)
            {
                partDisplayersManager.TryRemoveTaskDisplayer(part);
            }
        }
    }
}