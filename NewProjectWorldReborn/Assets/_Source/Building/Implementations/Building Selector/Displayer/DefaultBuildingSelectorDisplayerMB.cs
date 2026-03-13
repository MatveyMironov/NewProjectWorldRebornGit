using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class DefaultBuildingSelectorDisplayerMB : ABuildingSelectorDisplayerMB
    {
        [SerializeField] private ABuildingDisplayerMB buildingDisplayer;

        private IBuildingSelector _displayedSelector;

        protected virtual void OnDestroy()
        {
            Clear();
        }

        public override void DisplayBuildingSelector(IBuildingSelector selector)
        {
            Clear();
            _displayedSelector = selector;

            selector.OnBuildingSelected += DisplaySelectedBuilding;

            selector.OnBuildingDeselected += HideSelectedBuilding;
        }

        public override void Clear()
        {
            if (_displayedSelector == null) { return; }

            _displayedSelector.OnBuildingSelected -= DisplaySelectedBuilding;
            HideSelectedBuilding();

            _displayedSelector.OnBuildingDeselected -= HideSelectedBuilding;

            _displayedSelector = null;
        }

        private void DisplaySelectedBuilding(Building building)
        {
            buildingDisplayer.DisplayBuilding(building);
        }

        private void HideSelectedBuilding()
        {
            //Debug.Log("Selected building hidden");
            buildingDisplayer.Clear();
        }
    }
}