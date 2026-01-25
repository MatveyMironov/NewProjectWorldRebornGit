using System;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingSelectorMB : MonoBehaviour, IBuildingSelector
    {
        private IBuildingSelector _selector;

        private void Awake()
        {
            _selector = new BuildingSelector();
        }

        public event Action<Building> OnBuildingSelected
        {
            add => _selector.OnBuildingSelected += value;
            remove => _selector.OnBuildingSelected -= value;
        }

        public void SelectBuilding(Building building)
        {
            _selector.SelectBuilding(building);
        }
    }
}