using System;

namespace BuildingSystem
{
    public class BuildingSelector : IBuildingSelector
    {
        public event Action<Building> OnBuildingSelected;

        public void SelectBuilding(Building building)
        {
            OnBuildingSelected?.Invoke(building);
        }
    }
}