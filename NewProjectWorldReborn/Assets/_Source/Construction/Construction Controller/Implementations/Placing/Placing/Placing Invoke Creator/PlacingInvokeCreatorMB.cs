using ConstructionGridSystem;
using ConstructionPreviewSystem;
using CellsVisualizationSystem;
using System;
using UnityEngine;
using ConstructionControllerSystem;
using ConstructionConfigurationSystem;

namespace PlacingSystem
{
    public class PlacingInvokeCreatorMB : MonoBehaviour, IPlacingInvokeCreator
    {
        [SerializeField] private ConstructionControllerMB constructionController;

        [Space]
        [SerializeField] private ConstructionGridManagerMB constructionGridManager;
        [SerializeField] private ConstructionPreviewControllerMB constructionPreviewController;
        [SerializeField] private ACellsVisualizationMB occupiedCellsVisualization;
        [SerializeField] private BuildingViewInstantiatorMB buildingViewCreator;

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

        public Action CreatePlacingInvoke(IConstructionConfiguration constructionConfiguration, Action<BuildingStructure> buildingPlacedCallback)
        {
            return _placingInvokeCreator.CreatePlacingInvoke(constructionConfiguration, buildingPlacedCallback);
        }
    }
}
