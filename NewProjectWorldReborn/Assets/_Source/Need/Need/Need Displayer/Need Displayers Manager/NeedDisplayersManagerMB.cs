using UnityEngine;

namespace NeedSystem
{
    public class NeedDisplayersManagerMB : MonoBehaviour, INeedDisplayersManager
    {
        [SerializeField] private NeedDisplayerSpawnerMB displayerSpawner;

        private INeedDisplayersManager _displayersManager;

        private void Awake()
        {
            _displayersManager = new NeedDisplayersManager(displayerSpawner);
        }

        public bool TryAddNeed(INeed need)
        {
            return _displayersManager.TryAddNeed(need);
        }

        public bool TryRemoveNeed(INeed need)
        {
            return _displayersManager.TryRemoveNeed(need);
        }
    }
}