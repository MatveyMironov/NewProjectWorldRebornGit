using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class BuildingTaskInfo : ICustomInfo
    {
        private readonly BuildingTask _task;
        private readonly BuildingTaskDisplayerMB _displayerPrefab;

        public BuildingTaskInfo(BuildingTask task, BuildingTaskDisplayerMB displayerPrefab)
        {
            _task = task ?? throw new ArgumentNullException(nameof(task));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            BuildingTaskDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayBuildingTask(_task);
            return displayer.gameObject;
        }
    }
}