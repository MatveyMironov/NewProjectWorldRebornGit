using CustomInfoSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgressionSystem.Implementations
{
    public class CompositeTask : ITask
    {
        private readonly HashSet<ITask> _unfinishedTasks = new();
        private readonly HashSet<ITask> _completedTasks = new();

        public CompositeTask(ITask[] tasks, CompositeTaskDisplayerMB displayerPrefab)
        {
            Setup();

            Info = new CompositeTaskInfo(this, displayerPrefab);

            void Setup()
            {
                foreach (ITask task in tasks)
                {
                    AddTask(task);
                }

                TryComplete();
            }

            void AddTask(ITask task)
            {
                if (task.IsCompleted)
                {
                    _completedTasks.Add(task);
                }
                else
                {
                    _unfinishedTasks.Add(task);
                    task.OnCompleted += MoveTask;
                }

                void MoveTask()
                {
                    _unfinishedTasks.Remove(task);
                    _completedTasks.Add(task);

                    task.OnCompleted -= MoveTask;

                    TryComplete();
                }
            }

            void TryComplete()
            {
                if (IsCompleted)
                {
                    OnCompleted?.Invoke();
                }
            }
        }

        public HashSet<ITask> Parts => new(_unfinishedTasks.Union(_completedTasks));
        public HashSet<ITask> UnfinishedTasks => new(_unfinishedTasks);
        public HashSet<ITask> CompletedTasks => new(_completedTasks);

        public bool IsCompleted { get { return _unfinishedTasks.Count <= 0; } }
        public event Action OnCompleted;

        public ICustomInfo Info { get; }
    }
}