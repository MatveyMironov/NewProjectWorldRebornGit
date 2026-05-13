using CellsVisualizationSystem;
using ConstructionControllerSystem;
using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using StorageSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionResourcesSystem
{
    public class InvokeConstructionResourcesPlacingFactoryMB : MonoBehaviour, IInvokeConstructionResourcesPlacingFactory
    {
        [SerializeField] private ConstructionControllerMB constructionController;

        [Space]
        [SerializeField] private ConstructionGridManagerSO constructionGridManager;
        [SerializeField] private ConstructionPreviewFactoryMB constructionPreviewController;
        [SerializeField] private ACellsVisualizationMB occupiedCellsVisualization;
        [SerializeField] private BuildingStructureFactoryMB buildingViewCreator;

        [Space]
        [SerializeField] private BuildingRotationControllerMB buildingRotationController;

        private IInvokeConstructionResourcesPlacingFactory _factory;

        private void Awake()
        {
            IStorage storage = StorageSingleton.Instance;
            _factory = new InvokeConstructionResourcesPlacingFactory(constructionGridManager,
                                                                     constructionPreviewController,
                                                                     occupiedCellsVisualization,
                                                                     buildingViewCreator,
                                                                     buildingRotationController,
                                                                     constructionController,
                                                                     storage);
        }

        public Action CreateInvokePlacing(IConstructionConfiguration constructionConfiguration,
                                          Action<BuildingStructure> structurePlacedCallback,
                                          Dictionary<IResourceDefinition, int> requiredResourcesDictionary)
        {
            return _factory.CreateInvokePlacing(constructionConfiguration, structurePlacedCallback, requiredResourcesDictionary);
        }
    }
}