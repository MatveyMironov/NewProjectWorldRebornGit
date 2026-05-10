using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using ConstructionControllerSystem;

namespace PlacingSystem
{
    public class PlacingInvokeCreator : IPlacingInvokeCreator
    {
        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewFactory _constructionPreviewController;
        private readonly ICellsVisualization _occupiedCellsVisualization;
        private readonly IBuildingStructureFactory _buildingViewInstantiator;

        private readonly IBuildingRotationController _buildingRotationController;
        private readonly IConstructionController _constructionController;

        public PlacingInvokeCreator(IConstructionGridManager constructionGridManager,
                                    IConstructionPreviewFactory constructionPreviewController,
                                    ICellsVisualization occupiedCellsVisualization,
                                    IBuildingStructureFactory buildingViewInstantiator,
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

        public Action CreatePlacingInvoke(IConstructionConfiguration constructionConfiguration)
        {
            PlacingState placingState = new(constructionConfiguration,
                                            _constructionGridManager,
                                            _constructionPreviewController,
                                            _occupiedCellsVisualization,
                                            _buildingViewInstantiator);

            return InvokePlacing;

            void InvokePlacing()
            {
                _buildingRotationController.ProvidePlacingState(placingState);
                _constructionController.EnterState(placingState);
            }
        }
    }
}