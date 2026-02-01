using ManufactureSystem;
using System.Collections.Generic;

namespace BuildingSystem.Implementations
{
    public class BuildingManufacturesManager : IBuildingManufacturesManager
    {
        private readonly IManufacturesManager _manufacturesManager;

        public BuildingManufacturesManager(IManufacturesManager manufacturesManager)
        {
            _manufacturesManager = manufacturesManager ?? throw new System.ArgumentNullException(nameof(manufacturesManager));
        }

        private readonly Dictionary<Building, IManufacture> _buildingManufactures = new();

        public bool TryAddBuildingManufacture(Building building, IManufacture manufacture)
        {
            if (_buildingManufactures.TryAdd(building, manufacture))
            {
                _manufacturesManager.TryAddManufacture(manufacture);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingManufacture(Building building)
        {
            if (_buildingManufactures.Remove(building, out IManufacture manufacture))
            {
                _manufacturesManager.TryRemoveManufacture(manufacture);
                return true;
            }

            return false;
        }
    }
}