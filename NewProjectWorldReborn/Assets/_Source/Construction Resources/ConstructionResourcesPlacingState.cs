using CellsVisualizationSystem;
using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using StorageSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionResourcesSystem
{
    public class ConstructionResourcesPlacingState : IPlacingState
    {
        private readonly IPlacingState _placingState;

        private readonly IStorage _storage;
        private readonly Dictionary<IResourceDefinition, int> _requiredResourcesDictionary;

        public ConstructionResourcesPlacingState(IConstructionConfiguration constructionConfiguration,
                                                 IConstructionGridManager constructionGridManager,
                                                 IConstructionPreviewFactory previewFactory,
                                                 ICellsVisualization placementCellsVisualization,
                                                 IBuildingStructureFactory structureFactory,
                                                 Action<BuildingStructure> structurePlacedCallback,
                                                 IStorage storage,
                                                 Dictionary<IResourceDefinition, int> requiredResourcesDictionary)
        {
            structurePlacedCallback += structure => ConsumeResources();

            _placingState = new PlacingState(constructionConfiguration,
                                             constructionGridManager,
                                             previewFactory,
                                             placementCellsVisualization,
                                             structureFactory,
                                             structurePlacedCallback);

            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _requiredResourcesDictionary = requiredResourcesDictionary ?? throw new ArgumentNullException(nameof(requiredResourcesDictionary));
        }

        public void EnterState() => _placingState.EnterState();
        public void ExitState() => _placingState.ExitState();
        public void FinishAction() => _placingState.FinishAction();
        public void RotateBuilding() => _placingState.RotateBuilding();
        public void UpdateState(Vector2Int cell) => _placingState.UpdateState(cell);

        public void StartAction()
        {
            if (!CheckIfEnoughResources()) { return; }

            _placingState.FinishAction();

            bool CheckIfEnoughResources()
            {
                foreach (IResourceDefinition requiredResource in _requiredResourcesDictionary.Keys)
                {
                    int requiredCount = _requiredResourcesDictionary[requiredResource];
                    int availableCount = _storage.GetResourceCount(requiredResource);

                    if (availableCount < requiredCount) { return false; }
                }

                return true;
            }
        }

        private void ConsumeResources()
        {
            foreach (IResourceDefinition requiredResource in _requiredResourcesDictionary.Keys)
            {
                int requiredCount = _requiredResourcesDictionary[requiredResource];

                if (!_storage.TryRemoveResource(requiredResource, requiredCount))
                {
                    Debug.Log("Error: unaible to consume resources, required for construction!");
                }
            }
        }
    }
}