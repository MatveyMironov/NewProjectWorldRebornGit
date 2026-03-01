using UnityEngine;

namespace BuildingViewSystem
{
    public class BuildingViewMB : MonoBehaviour
    {
        [SerializeField] private GameObject demolitionIndicator;

        private void Start()
        {
            HideDemolition();
        }

        public void ShowDemolition()
        {
            demolitionIndicator.SetActive(true);
        }

        public void HideDemolition()
        {
            demolitionIndicator.SetActive(false);
        }
    }
}