using System;
using System.Collections.Generic;

namespace BuildingSystem
{
    public class BuildingInteractionsManager : IBuildingInteractionsManager
    {
        private readonly IBuildingSelector _buildingSelector;

        public BuildingInteractionsManager(IBuildingSelector buildingSelector)
        {
            _buildingSelector = buildingSelector ?? throw new ArgumentNullException(nameof(buildingSelector));
        }

        private readonly Dictionary<Building, Action> _buildings_interactions = new();

        public bool TryAddBuildingInteraction(Building building)
        {
            if (_buildings_interactions.TryAdd(building, null))
            {
                _buildings_interactions[building] = Interact;
                building.Structure.View.OnInteracted += _buildings_interactions[building];

                void Interact()
                {
                    _buildingSelector.SelectBuilding(building);
                }

                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingInteraction(Building building)
        {
            if (_buildings_interactions.Remove(building, out Action interact))
            {
                building.Structure.View.OnInteracted -= interact;
                return true;
            }

            return false;
        }

        public bool TryGetBuildingInteraction(Building building, out Action interact)
        {
            return _buildings_interactions.TryGetValue(building, out interact);
        }
    }
}