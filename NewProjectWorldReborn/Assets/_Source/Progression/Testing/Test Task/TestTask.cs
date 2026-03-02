using CustomInfoSystem;
using System;

namespace ProgressionSystem.Testing
{
    public class TestTask : ITask
    {
        public TestTask(string name, TestTaskDisplayerMB displayerPrefab)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            Info = new TestTaskInfo(this, displayerPrefab);
        }

        public string Name { get; }

        public bool IsCompleted { get; private set; }
        public event Action OnCompleted;

        public ICustomInfo Info { get; }

        public void Compete()
        {
            if (IsCompleted) return;

            IsCompleted = true;
            OnCompleted?.Invoke();
        }
    }
}