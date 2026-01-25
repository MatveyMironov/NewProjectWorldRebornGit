using System;

namespace BuildingSystem
{
    public interface IBuildingSelector
    {
        event Action<Building> OnBuildingSelected;

        void SelectBuilding(Building building);
    }
}