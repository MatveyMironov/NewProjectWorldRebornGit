using System;
using UnityEngine;

namespace BuildingViewSystem
{
    public class BuildingViewMB : MonoBehaviour
    {
        [SerializeField] private GameObject demolitionIndicator;

        public event Action OnSelectedForDemolition;
        public event Action OnDeselectedForDemolition;

        private void Start()
        {
            OnDeselectForDemolition();
        }

        public void OnSelectForDemolition()
        {
            demolitionIndicator.SetActive(true);
        }

        public void OnDeselectForDemolition()
        {
            demolitionIndicator.SetActive(false);
        }

        public void Demolish()
        {
            Destroy(gameObject);
        }
    }
}