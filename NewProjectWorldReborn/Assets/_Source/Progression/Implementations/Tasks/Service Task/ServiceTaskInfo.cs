using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class ServiceTaskInfo : ICustomInfo
    {
        private readonly ServiceTask _task;
        private readonly ServiceTaskDisplayerMB _displayerPrefab;

        public ServiceTaskInfo(ServiceTask task, ServiceTaskDisplayerMB displayerPrefab)
        {
            _task = task ?? throw new ArgumentNullException(nameof(task));
            _displayerPrefab = displayerPrefab ?? throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            ServiceTaskDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayServiceTask(_task);
            return displayer.gameObject;
        }
    }
}