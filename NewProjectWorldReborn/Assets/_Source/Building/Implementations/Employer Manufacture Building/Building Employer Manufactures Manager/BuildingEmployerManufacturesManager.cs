using EmployerManufactureSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingEmployerManufacturesManager : IBuildingEmployerManufacturesManager
    {
        private readonly IBuildingEmployersManager _buildingEmployersManager;
        private readonly IBuildingManufacturesManager _buildingManufacturesManager;

        public BuildingEmployerManufacturesManager(IBuildingEmployersManager buildingEmployersManager, IBuildingManufacturesManager buildingManufacturesManager)
        {
            _buildingEmployersManager = buildingEmployersManager ?? throw new ArgumentNullException(nameof(buildingEmployersManager));
            _buildingManufacturesManager = buildingManufacturesManager ?? throw new ArgumentNullException(nameof(buildingManufacturesManager));
        }

        private readonly Dictionary<Building, IEmployerManufacture> _buildings_employerManufactures = new();

        public Building[] Buildings => _buildings_employerManufactures.Keys.ToArray();

        public event Action<Building> OnBuildingAdded;
        public event Action<Building> OnBuildingRemoved;

        public bool TryAddBuildingEmployerManufacture(Building building, IEmployerManufacture employerManufacture)
        {
            if (_buildings_employerManufactures.TryAdd(building, employerManufacture))
            {
                //Debug.Log($"Building {building} added");
                OnBuildingAdded?.Invoke(building);
                _buildingEmployersManager.TryAddBuildingEmployer(building, employerManufacture.Employer);
                _buildingManufacturesManager.TryAddBuildingManufacture(building, employerManufacture.Manufacture);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingEmployerManufacture(Building building)
        {
            if (_buildings_employerManufactures.Remove(building, out IEmployerManufacture employerManufacture))
            {
                //Debug.Log($"Building {building} removed");
                OnBuildingRemoved?.Invoke(building);
                _buildingEmployersManager.TryRemoveBuildingEmployer(building);
                _buildingManufacturesManager.TryRemoveBuildingManufacture(building);
                return true;
            }

            return false;
        }

        public bool TryGetBuildingEmployerManufacture(Building building, out IEmployerManufacture employerManufacture)
        {
            return _buildings_employerManufactures.TryGetValue(building, out employerManufacture);
        }
    }
}