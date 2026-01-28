using CustomInfoSystem;
using System;

namespace ProgressionSystem
{
    public interface ITask
    {
        public bool IsCompleted { get; }
        public event Action OnCompleted;

        public ICustomInfo Info { get; }
    }
}