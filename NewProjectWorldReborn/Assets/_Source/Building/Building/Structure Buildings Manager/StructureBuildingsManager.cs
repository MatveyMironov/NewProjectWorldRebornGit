using ConstructionGridSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingSystem
{
    public class StructureBuildingsManager : IStructureBuildingsManager
    {
        private readonly Dictionary<BuildingStructure, Building> _structureBuildings = new();

        public Building[] Buildings => _structureBuildings.Values.ToArray();
        public event Action<Building> OnBuildingAdded;
        public event Action<Building> OnBuildingRemoved;

        public bool TryAddStructureBuilding(BuildingStructure structure, Building building)
        {
            if (_structureBuildings.TryAdd(structure, building))
            {
                //Debug.Log($"Building {building} for structure {structure} was added");
                OnBuildingAdded?.Invoke(building);
                return true;
            }

            return false;
        }

        public bool TryRemoveBuildingInterior(BuildingStructure structure)
        {
            if (_structureBuildings.Remove(structure, out Building building))
            {
                //Debug.Log($"Building {building} for structure {structure} was removed");
                OnBuildingRemoved?.Invoke(building);
                return true;
            }

            return false;
        }

        public bool TryGetBuildingInterior(BuildingStructure structure, out Building building)
        {
            return _structureBuildings.TryGetValue(structure, out building);
        }
    }
}