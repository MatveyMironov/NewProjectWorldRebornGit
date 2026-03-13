using System;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingInteractionsManagerMB : MonoBehaviour, IBuildingInteractionsManager
    {
        [SerializeField] private BuildingSelectorMB selector;

        private IBuildingInteractionsManager _manager;

        private void Awake()
        {
            _manager = new BuildingInteractionsManager(selector);
        }

        public bool TryAddBuildingInteraction(Building building)
        {
            return _manager.TryAddBuildingInteraction(building);
        }

        public bool TryRemoveBuildingInteraction(Building building)
        {
            return _manager.TryRemoveBuildingInteraction(building);
        }

        public bool TryGetBuildingInteraction(Building building, out Action interact)
        {
            return _manager.TryGetBuildingInteraction(building, out interact);
        }
    }
}