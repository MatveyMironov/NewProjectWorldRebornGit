using ManufactureSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSystem.Implementations
{
    public class BuildingManufacturesManager : IBuildingManufacturesManager
    {
        private readonly IManufacturesManager _manufacturesManager;

        public BuildingManufacturesManager(IManufacturesManager manufacturesManager)
        {
            _manufacturesManager = manufacturesManager ?? throw new System.ArgumentNullException(nameof(manufacturesManager));
        }

        private readonly Dictionary<Building, IManufacture> _buildings_Manufactures = new();

        public Building[] Buildings => _buildings_Manufactures.Keys.ToArray();

        public event Action<Building> OnBuildingAdded;
        public event Action<Building> OnBuildingRemoved;

        public bool TryAddBuildingManufacture(Building building, IManufacture manufacture)
        {
            if (_buildings_Manufactures.TryAdd(building, manufacture))
            {
                _manufacturesManager.TryAddManufacture(manufacture);
                OnBuildingAdded?.Invoke(building);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingManufacture(Building building)
        {
            if (_buildings_Manufactures.Remove(building, out IManufacture manufacture))
            {
                _manufacturesManager.TryRemoveManufacture(manufacture);
                OnBuildingRemoved?.Invoke(building);
                return true;
            }

            return false;
        }

        public bool TryGetBuildingManufacture(Building building, out IManufacture manufacture)
        {
            return _buildings_Manufactures.TryGetValue(building, out manufacture);
        }
    }
}