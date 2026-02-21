using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Testing
{
    public class TestTaskInfo : ICustomInfo
    {
        private readonly TestTask _task;
        private readonly TestTaskDisplayerMB _displayerPrefab;

        public TestTaskInfo(TestTask task, TestTaskDisplayerMB displayerPrefab)
        {
            _task = task ?? throw new ArgumentNullException(nameof(task));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            TestTaskDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayTask(_task);
            return displayer.gameObject;
        }
    }
}