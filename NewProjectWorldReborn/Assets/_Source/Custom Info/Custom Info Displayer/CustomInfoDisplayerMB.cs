using UnityEngine;

namespace CustomInfoSystem
{
    public class CustomInfoDisplayerMB : MonoBehaviour, ICustomInfoDisplayer
    {
        [SerializeField] private Transform parent;

        private GameObject _displayedInfoObject;

        public void DisplayInfo(ICustomInfo info)
        {
            Clear();

            _displayedInfoObject = info.CreateInfoObject();
            _displayedInfoObject.transform.SetParent(parent);
        }

        public void Clear()
        {
            if (_displayedInfoObject == null) return;

            Destroy(_displayedInfoObject);
        }
    }
}