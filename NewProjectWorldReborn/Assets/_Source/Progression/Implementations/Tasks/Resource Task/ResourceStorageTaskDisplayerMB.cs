using CustomUISystem;
using ResourceSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class ResourceStorageTaskDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB storedAmountDisplayer;
        [SerializeField] private ANumberDisplayerMB targetAmountDisplayer;
        [SerializeField] private AResourceDisplayerMB targetResourceDisplayer;

        private ResourceStorageTask _displayedTask;

        private void OnDestroy()
        {
            RemoveDisplayedTask();
        }

        public void DisplayTask(ResourceStorageTask task)
        {
            RemoveDisplayedTask();

            DisplayTaskStoredAmount();
            DisplayTaskTargetAmount();
            DisplayTaskTargetResource();

            _displayedTask = task;

            void DisplayTaskStoredAmount()
            {
                DisplayStoredAmount(task.StoredAmount);
                task.OnStoredAmountChanged += DisplayStoredAmount;
            }

            void DisplayTaskTargetAmount()
            {
                DisplayTargetAmount(task.TargetAmount);
            }

            void DisplayTaskTargetResource()
            {
                DisplayTargetResource(task.TargetResource);
            }
        }

        public void RemoveDisplayedTask()
        {
            if (_displayedTask == null) return;

            _displayedTask.OnStoredAmountChanged -= DisplayStoredAmount;

            _displayedTask = null;
        }

        private void DisplayStoredAmount(int amount)
        {
            storedAmountDisplayer.DisplayNumber(amount);
        }

        private void DisplayTargetAmount(int amount)
        {
            targetAmountDisplayer.DisplayNumber(amount);
        }

        private void DisplayTargetResource(IResourceDefinition resource)
        {
            targetResourceDisplayer.DisplayResource(resource);
        }
    }
}