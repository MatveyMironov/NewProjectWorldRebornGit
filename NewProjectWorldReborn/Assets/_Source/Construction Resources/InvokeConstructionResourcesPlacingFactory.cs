using CellsVisualizationSystem;
using ConstructionControllerSystem;
using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using StorageSystem;
using System;
using System.Collections.Generic;

namespace ConstructionResourcesSystem
{
    public class InvokeConstructionResourcesPlacingFactory : IInvokeConstructionResourcesPlacingFactory
    {
        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewFactory _constructionPreviewFactory;
        private readonly ICellsVisualization _placmentCellsVisualization;
        private readonly IBuildingStructureFactory _structureFactory;

        private readonly IBuildingRotationController _rotationController;
        private readonly IConstructionController _constructionController;

        private readonly IStorage _storage;

        public InvokeConstructionResourcesPlacingFactory(IConstructionGridManager constructionGridManager,
                                                         IConstructionPreviewFactory constructionPreviewFactory,
                                                         ICellsVisualization occupiedCellsVisualization,
                                                         IBuildingStructureFactory structureFactory,
                                                         IBuildingRotationController rotationController,
                                                         IConstructionController constructionController,
                                                         IStorage storage)
        {
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _constructionPreviewFactory = constructionPreviewFactory ?? throw new ArgumentNullException(nameof(constructionPreviewFactory));
            _placmentCellsVisualization = occupiedCellsVisualization ?? throw new ArgumentNullException(nameof(occupiedCellsVisualization));
            _structureFactory = structureFactory ?? throw new ArgumentNullException(nameof(structureFactory));

            _rotationController = rotationController ?? throw new ArgumentNullException(nameof(rotationController));
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));

            _storage = storage;
        }

        public Action CreateInvokePlacing(IConstructionConfiguration constructionConfiguration,
                                          Action<BuildingStructure> structurePlacedCallback,
                                          Dictionary<IResourceDefinition, int> requiredResourcesDictionary)
        {
            ConstructionResourcesPlacingState placing = new(constructionConfiguration,
                                                            _constructionGridManager,
                                                            _constructionPreviewFactory,
                                                            _placmentCellsVisualization,
                                                            _structureFactory,
                                                            structurePlacedCallback,
                                                            _storage,
                                                            requiredResourcesDictionary);

            return InvokePlacing;

            void InvokePlacing()
            {
                _rotationController.ProvidePlacingState(placing);
            }
        }
    }
}