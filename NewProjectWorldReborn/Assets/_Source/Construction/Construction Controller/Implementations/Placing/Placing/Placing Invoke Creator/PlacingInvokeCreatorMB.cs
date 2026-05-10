using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using UnityEngine;
using ConstructionControllerSystem;

namespace PlacingSystem
{
    public class PlacingInvokeCreatorMB : MonoBehaviour, IPlacingInvokeCreator
    {
        [SerializeField] private ConstructionControllerMB constructionController;

        [Space]
        [SerializeField] private ConstructionGridManagerMB constructionGridManager;
        [SerializeField] private ConstructionPreviewFactoryMB constructionPreviewController;
        [SerializeField] private ACellsVisualizationMB occupiedCellsVisualization;
        [SerializeField] private BuildingStructureFactoryMB buildingViewCreator;

        [Space]
        [SerializeField] private BuildingRotationControllerMB buildingRotationController;

        private IPlacingInvokeCreator _placingInvokeCreator;

        private void Awake()
        {
            _placingInvokeCreator = new PlacingInvokeCreator(constructionGridManager,
                                                             constructionPreviewController,
                                                             occupiedCellsVisualization,
                                                             buildingViewCreator,
                                                             buildingRotationController,
                                                             constructionController);
        }

        public Action CreatePlacingInvoke(IConstructionConfiguration constructionConfiguration)
        {
            return _placingInvokeCreator.CreatePlacingInvoke(constructionConfiguration);
        }
    }
}