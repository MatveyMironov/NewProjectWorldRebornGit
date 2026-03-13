using System;

namespace BuildingSystem
{
    public interface IBuildingSelector
    {
        Building SelectedBuilding { get; }
        event Action<Building> OnBuildingSelected;
        event Action OnBuildingDeselected;

        void SelectBuilding(Building building);
        void DeselectBuilding();
    }
}