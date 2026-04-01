using CellsVisualizationSystem;
using ConstructionControllerSystem;
using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using StorageSystem;
using System;
using System.Collections.Generic;

namespace ConstructionResourcesPlacingSystem
{
    public class ConstructionResourcesPlacingInvokeCreator : IConstructionResourcesPlacingInvokeCreator
    {
        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewController _constructionPreviewController;
        private readonly ICellsVisualization _occupiedCellsVisualization;
        private readonly IBuildingStructureCreator _buildingViewInstantiator;

        private readonly IStorage _storage;

        private readonly IBuildingRotationController _buildingRotationController;
        private readonly IConstructionController _constructionController;

        public ConstructionResourcesPlacingInvokeCreator(IConstructionGridManager constructionGridManager,
                                                         IConstructionPreviewController constructionPreviewController,
                                                         ICellsVisualization occupiedCellsVisualization,
                                                         IBuildingStructureCreator buildingViewInstantiator,
                                                         IBuildingRotationController buildingRotationController,
                                                         IConstructionController constructionController,
                                                         IStorage storage)
        {
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _constructionPreviewController = constructionPreviewController ?? throw new ArgumentNullException(nameof(constructionPreviewController));
            _occupiedCellsVisualization = occupiedCellsVisualization ?? throw new ArgumentNullException(nameof(occupiedCellsVisualization));
            _buildingViewInstantiator = buildingViewInstantiator ?? throw new ArgumentNullException(nameof(buildingViewInstantiator));

            _buildingRotationController = buildingRotationController ?? throw new ArgumentNullException(nameof(buildingRotationController));
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public Action CreateInvoke(IConstructionConfiguration constructionConfiguration, Dictionary<IResourceDefinition, int> constructionResources)
        {
            ConstructionResourcesPlacingState state = new(constructionConfiguration,
                                            _constructionGridManager,
                                            _constructionPreviewController,
                                            _occupiedCellsVisualization,
                                            _buildingViewInstantiator,
                                            _storage,
                                            constructionResources);

            return InvokePlacing;

            void InvokePlacing()
            {
                _constructionController.EnterState(state);
            }
        }
    }
}