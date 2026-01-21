using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedSystem
{
    public class NeedsManager : INeedsManager
    {
        private readonly HashSet<INeed> _needs = new();

        public INeed[] Needs => _needs.ToArray();

        public event Action<INeed> OnNeedAdded;
        public event Action<INeed> OnNeedRemoved;

        public bool TryAddNeed(INeed need)
        {
            if (_needs.Add(need))
            {
                OnNeedAdded?.Invoke(need);
                return true;
            }

            return false;
        }

        public bool TryRemoveNeed(INeed need)
        {
            if (_needs.Remove(need))
            {
                OnNeedRemoved?.Invoke(need);
                return true;
            }

            return false;
        }
    }
}