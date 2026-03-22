using BuildingSystem;
using CustomUISystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class BuildingTaskDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ABuildingConfigurationDisplayerMB requiredBuildingConfigurationDisplayer;
        [SerializeField] private ANumberDisplayerMB requiredCountDisplayer;
        [SerializeField] private ANumberDisplayerMB actualCountDisplayer;

        private BuildingTask _displayedTask;

        private void OnDestroy()
        {
            Clear();
        }

        public void DisplayBuildingTask(BuildingTask task)
        {
            Clear();
            _displayedTask = task;

            requiredBuildingConfigurationDisplayer.DisplayBuildingConiguration(task.RequiredBuildingConfiguration);
            requiredCountDisplayer.DisplayNumber(task.RequiredCount);

            task.OnActualCountChanged += DisplayActualCount;
            DisplayActualCount();
        }

        public void Clear()
        {
            if (_displayedTask == null) return;

            _displayedTask.OnActualCountChanged -= DisplayActualCount;

            _displayedTask = null;
        }

        private void DisplayActualCount()
        {
            actualCountDisplayer.DisplayNumber(_displayedTask.ActualCount);
        }
    }
}