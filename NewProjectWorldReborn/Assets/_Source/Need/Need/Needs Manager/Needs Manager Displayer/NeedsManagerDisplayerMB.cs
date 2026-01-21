using UnityEngine;

namespace NeedSystem
{
    public class NeedsManagerDisplayerMB : MonoBehaviour, INeedsManagerDisplayer
    {
        [SerializeField] private NeedDisplayersManagerMB needDisplayersManager;

        private INeedsManager _displayedManager;

        public void DisplayNeedsManager(INeedsManager manager)
        {
            Clear();

            foreach (var need in manager.Needs)
            {
                DisplayNeed(need);
            }

            manager.OnNeedAdded += DisplayNeed;
            manager.OnNeedRemoved += HideNeed;

            _displayedManager = manager;
        }

        public void Clear()
        {
            if (_displayedManager == null) return;

            _displayedManager.OnNeedAdded -= DisplayNeed;
            _displayedManager.OnNeedRemoved -= HideNeed;

            foreach (var demand in _displayedManager.Needs)
            {
                HideNeed(demand);
            }

            _displayedManager = null;
        }

        private void DisplayNeed(INeed demand)
        {
            needDisplayersManager.TryAddNeed(demand);
        }

        private void HideNeed(INeed demand)
        {
            needDisplayersManager.TryRemoveNeed(demand);
        }
    }
}