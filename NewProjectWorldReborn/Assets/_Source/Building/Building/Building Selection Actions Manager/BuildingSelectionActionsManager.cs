using System;
using System.Collections.Generic;

namespace BuildingSystem
{
    public class BuildingSelectionActionsManager : IBuildingSelectionActionsManager
    {
        private readonly IBuildingSelector _buildingSelector;

        public BuildingSelectionActionsManager(IBuildingSelector buildingMenu)
        {
            _buildingSelector = buildingMenu ?? throw new ArgumentNullException(nameof(buildingMenu));
        }

        private readonly Dictionary<Building, Action> _buildingSelectionActions = new();

        public bool TryAddBuildingSelectionAction(Building building)
        {
            if (_buildingSelectionActions.TryAdd(building, null))
            {
                Action selectBuilding = SelectBuilding;
                building.Structure.View.OnSelected += selectBuilding;

                void SelectBuilding()
                {
                    _buildingSelector.SelectBuilding(building);
                }

                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingSelectionAction(Building building)
        {
            if (_buildingSelectionActions.Remove(building, out Action selectBuilding))
            {
                building.Structure.View.OnSelected -= selectBuilding;
                return true;
            }

            return false;
        }

        public bool TryGetBuildingSelectionAction(Building building, out Action selectBuilding)
        {
            return _buildingSelectionActions.TryGetValue(building, out selectBuilding);
        }
    }
}