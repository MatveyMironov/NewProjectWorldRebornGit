using CustomInfoSystem;
using System;

namespace ProgressionSystem.Implementations
{
    public class EmptyTask : ITask
    {
        public bool IsCompleted => true;

        public ICustomInfo Info { get; } = new EmptyTaskInfo();

        public event Action OnCompleted;
    }
}