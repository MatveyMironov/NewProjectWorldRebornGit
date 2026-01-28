using System.Collections.Generic;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class TaskDisplayersManagerMB : ATaskDisplayersManagerMB
    {
        [SerializeField] private ATaskDisplayerSpawnerMB spawner;

        private readonly Dictionary<ITask, ATaskDisplayerMB> _displayers = new();

        public override bool TryAddTaskDisplayer(ITask task)
        {
            if (_displayers.TryAdd(task, null))
            {
                _displayers[task] = spawner.SpawnTaskDisplayer();
                _displayers[task].DisplayTask(task);
                return true;
            }

            return false;
        }

        public override bool TryRemoveTaskDisplayer(ITask task)
        {
            if (_displayers.Remove(task, out ATaskDisplayerMB taskDisplayer))
            {
                Destroy(taskDisplayer.gameObject);
                return true;
            }

            return false;
        }
    }
}