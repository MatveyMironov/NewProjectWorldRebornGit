using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using UnityEngine;
using ConstructionControllerSystem;

namespace PlacingSystem
{
    public class InvokePlacingFactoryMB : MonoBehaviour, IInvokePlacingFactory
    {
        [SerializeField] private ConstructionControllerMB constructionController;

        [Space]
        [SerializeField] private ConstructionGridManagerSO constructionGridManager;
        [SerializeField] private ConstructionPreviewFactoryMB constructionPreviewController;
        [SerializeField] private ACellsVisualizationMB occupiedCellsVisualization;
        [SerializeField] private BuildingStructureFactoryMB buildingViewCreator;

        [Space]
        [SerializeField] private BuildingRotationControllerMB buildingRotationController;

        private IInvokePlacingFactory _invokePlacingFactory;

        private void Awake()
        {
            _invokePlacingFactory = new InvokePlacingFactory(constructionGridManager,
                                                             constructionPreviewController,
                                                             occupiedCellsVisualization,
                                                             buildingViewCreator,
                                                             buildingRotationController,
                                                             constructionController);
        }

        public Action CreateInvokePlacing(IConstructionConfiguration constructionConfiguration, Action<BuildingStructure> structurePlacedCallback)
        {
            return _invokePlacingFactory.CreateInvokePlacing(constructionConfiguration, structurePlacedCallback);
        }
    }
}