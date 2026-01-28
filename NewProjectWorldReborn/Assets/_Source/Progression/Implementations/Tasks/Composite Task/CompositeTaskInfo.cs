using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class CompositeTaskInfo : ICustomInfo
    {
        private readonly CompositeTask _task;
        private readonly CompositeTaskDisplayerMB _displayerPrefab;

        public CompositeTaskInfo(CompositeTask task, CompositeTaskDisplayerMB displayerPrefab)
        {
            _task = task ?? throw new ArgumentNullException(nameof(task));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            CompositeTaskDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayCompositeTask(_task);
            return displayer.gameObject;
        }
    }
}