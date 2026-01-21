using System;
using UnityEngine;

namespace NeedSystem
{
    public class NeedsManagerMB : MonoBehaviour, INeedsManager
    {
        private INeedsManager _manager;

        private void Awake()
        {
            _manager = new NeedsManager();
        }

        public INeed[] Needs => _manager.Needs;

        public event Action<INeed> OnNeedAdded
        {
            add => _manager.OnNeedAdded += value;
            remove => _manager.OnNeedAdded -= value;
        }

        public event Action<INeed> OnNeedRemoved
        {
            add => _manager.OnNeedRemoved += value;
            remove => _manager.OnNeedRemoved -= value;
        }

        public bool TryAddNeed(INeed demand)
        {
            return _manager.TryAddNeed(demand);
        }

        public bool TryRemoveNeed(INeed demand)
        {
            return _manager.TryRemoveNeed(demand);
        }
    }
}