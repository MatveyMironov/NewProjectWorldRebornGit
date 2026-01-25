using ConstructionGridSystem;
using ConstructionPreviewSystem;
using CellsVisualizationSystem;
using System;
using ConstructionControllerSystem;
using ConstructionConfigurationSystem;

namespace PlacingSystem
{
    public class PlacingInvokeCreator : IPlacingInvokeCreator
    {
        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewController _constructionPreviewController;
        private readonly ICellsVisualization _occupiedCellsVisualization;
        private readonly IBuildingViewInstantiator _buildingViewInstantiator;

        private readonly IBuildingRotationController _buildingRotationController;
        private readonly IConstructionController _constructionController;

        public PlacingInvokeCreator(IConstructionGridManager constructionGridManager,
                                    IConstructionPreviewController constructionPreviewController,
                                    ICellsVisualization occupiedCellsVisualization,
                                    IBuildingViewInstantiator buildingViewInstantiator,
                                    IBuildingRotationController buildingRotationController,
                                    IConstructionController constructionController)
        {
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _constructionPreviewController = constructionPreviewController ?? throw new ArgumentNullException(nameof(constructionPreviewController));
            _occupiedCellsVisualization = occupiedCellsVisualization ?? throw new ArgumentNullException(nameof(occupiedCellsVisualization));
            _buildingViewInstantiator = buildingViewInstantiator ?? throw new ArgumentNullException(nameof(buildingViewInstantiator));

            _buildingRotationController = buildingRotationController ?? throw new ArgumentNullException(nameof(buildingRotationController));
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));
        }

        //private readonly Dictionary<IConstructionConfiguration, PlacingState> _placingStates = new();
        //private readonly Dictionary<PlacingState, Action<ConstructedBuildingData>> _buildingPlacedCallbacks = new();
        
        public Action CreatePlacingInvoke(IConstructionConfiguration constructionConfiguration, Action<ConstructedBuilding> buildingPlacedCallback)
        {
            PlacingState placingState = new(constructionConfiguration,
                                            _constructionGridManager,
                                            _constructionPreviewController,
                                            _occupiedCellsVisualization,
                                            _buildingViewInstantiator);

            placingState.OnBuildingPlaced += buildingPlacedCallback;

            return InvokePlacing;

            void InvokePlacing()
            {
                _buildingRotationController.ProvidePlacingState(placingState);
                _constructionController.SetState(placingState);
            }
        }

        //public bool TryRemovePlacingInvoke(IConstructionConfiguration constructionConfiguration)
        //{
        //    if (_placingStates.Remove(constructionConfiguration, out PlacingState placingState))
        //    {
        //        if (_buildingPlacedCallbacks.Remove(placingState, out Action<ConstructedBuildingData> callback))
        //        {
        //            placingState.OnBuildingPlaced -= callback;
        //        }

        //        return true;
        //    }

        //    return false;
        //}

        //public bool TryGetPlacingInvoke(IConstructionConfiguration constructionConfiguration, out Action<ConstructedBuildingData> callback)
        //{
        //    callback = null;

        //    if (_placingStates.TryGetValue(constructionConfiguration, out PlacingState placingState))
        //    {
        //        return _buildingPlacedCallbacks.TryGetValue(placingState, out callback);
        //    }

        //    return false;
        //}
    }
}
