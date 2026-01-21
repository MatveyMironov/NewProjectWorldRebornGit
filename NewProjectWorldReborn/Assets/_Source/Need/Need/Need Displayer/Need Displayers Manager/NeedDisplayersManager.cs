using System;
using System.Collections.Generic;

namespace NeedSystem
{
    public class NeedDisplayersManager : INeedDisplayersManager
    {
        private readonly INeedDisplayerSpawner _displayerSpawner;

        public NeedDisplayersManager(INeedDisplayerSpawner displayerSpawner)
        {
            _displayerSpawner = displayerSpawner ?? throw new ArgumentNullException(nameof(displayerSpawner));
        }

        private readonly Dictionary<INeed, ANeedDisplayerMB> _needDisplayers = new();

        public bool TryAddNeed(INeed need)
        {
            if (_needDisplayers.TryAdd(need, null))
            {
                _needDisplayers[need] = _displayerSpawner.SpawnNeedDisplayer();
                _needDisplayers[need].DisplayNeed(need);
                return true;
            }

            return false;
        }

        public bool TryRemoveNeed(INeed need)
        {
            if (_needDisplayers.Remove(need, out ANeedDisplayerMB displayer))
            {
                UnityEngine.Object.Destroy(displayer.gameObject);
                return true;
            }

            return false;
        }
    }
}