using CellsVisualizationSystem;
using ConstructionControllerSystem;
using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using StorageSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionResourcesPlacingSystem
{
    public class ConstructionResourcesPlacingInvokeCreatorMB : MonoBehaviour, IConstructionResourcesPlacingInvokeCreator
    {
        [SerializeField] private ConstructionControllerMB constructionController;

        [Space]
        [SerializeField] private ConstructionGridManagerMB constructionGridManager;
        [SerializeField] private ConstructionPreviewControllerMB constructionPreviewController;
        [SerializeField] private ACellsVisualizationMB occupiedCellsVisualization;
        [SerializeField] private BuildingViewInstantiatorMB buildingViewCreator;

        [Space]
        [SerializeField] private BuildingRotationControllerMB buildingRotationController;

        private IConstructionResourcesPlacingInvokeCreator _placingInvokeCreator;

        private void Awake()
        {
            _placingInvokeCreator = new ConstructionResourcesPlacingInvokeCreator(constructionGridManager,
                                                                                  constructionPreviewController,
                                                                                  occupiedCellsVisualization,
                                                                                  buildingViewCreator,
                                                                                  buildingRotationController,
                                                                                  constructionController,
                                                                                  StorageSingleton.Instance);
        }

        public Action CreateInvoke(IConstructionConfiguration constructionConfiguration, Dictionary<IResourceDefinition, int> constructionResources)
        {
            return _placingInvokeCreator.CreateInvoke(constructionConfiguration, constructionResources);
        }
    }
}