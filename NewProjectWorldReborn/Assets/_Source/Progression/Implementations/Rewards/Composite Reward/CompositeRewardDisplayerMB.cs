using System.Collections.Generic;
using UnityEngine;

namespace ProgressionSystem
{
    public class CompositeRewardDisplayerMB : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        private readonly List<GameObject> _infoObjects = new();

        public void DisplayReward(CompositeReward reward)
        {
            foreach (var part in reward.Parts)
            {
                var infoObject = part.Info.CreateInfoObject();
                infoObject.transform.SetParent(parent);
                _infoObjects.Add(infoObject);
            }
        }

        public void ClearDisplayer()
        {
            if (_infoObjects.Count <= 0) return;

            foreach (var infoObject in _infoObjects)
            {
                Destroy(infoObject);
            }

            _infoObjects.Clear();
        }
    }
}