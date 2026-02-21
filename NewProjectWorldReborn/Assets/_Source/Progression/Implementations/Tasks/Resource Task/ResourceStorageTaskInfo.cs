using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class ResourceStorageTaskInfo : ICustomInfo
    {
        private readonly ResourceStorageTask _task;
        private readonly ResourceStorageTaskDisplayerMB _displayerPrefab;

        public ResourceStorageTaskInfo(ResourceStorageTask task, ResourceStorageTaskDisplayerMB displayerPrefab)
        {
            _task = task ?? throw new ArgumentNullException(nameof(task));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            ResourceStorageTaskDisplayerMB displayer = GameObject.Instantiate(_displayerPrefab);
            displayer.DisplayTask(_task);

            return displayer.gameObject;
        }
    }
}