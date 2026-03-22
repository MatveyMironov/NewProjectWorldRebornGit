using EmployerSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingEmployersManager : IBuildingEmployersManager
    {
        private readonly IEmployersManager _employersManager;

        public BuildingEmployersManager(IEmployersManager employersManager)
        {
            _employersManager = employersManager ?? throw new ArgumentNullException(nameof(employersManager));
        }

        private readonly Dictionary<Building, IEmployer> _buildings_employers = new();
        public Building[] Buildings => _buildings_employers.Keys.ToArray();

        public event Action<Building> OnBuildingAdded;
        public event Action<Building> OnBuildingRemoved;

        public bool TryAddBuildingEmployer(Building building, IEmployer employer)
        {
            if (_buildings_employers.TryAdd(building, employer))
            {
                //Debug.Log($"Building {building} added");
                OnBuildingAdded?.Invoke(building);
                _employersManager.TryAddEmployer(employer);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingEmployer(Building building)
        {
            if (_buildings_employers.Remove(building, out IEmployer employer))
            {
                //Debug.Log($"Building {building} removed");
                OnBuildingRemoved?.Invoke(building);
                _employersManager.TryRemoveEmployer(employer);
                return true;
            }

            return false;
        }

        public bool TryGetBuildingEmployer(Building building, out IEmployer employer)
        {
            return _buildings_employers.TryGetValue(building, out employer);
        }
    }
}