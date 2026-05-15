using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using ConstructionControllerSystem;

namespace PlacingSystem
{
    public class InvokePlacingFactory : IInvokePlacingFactory
    {
        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewFactory _constructionPreviewFactory;
        private readonly ICellsVisualization _placmentCellsVisualization;
        private readonly IBuildingStructureFactory _structureFactory;

        private readonly IBuildingRotationController _rotationController;
        private readonly IConstructionController _constructionController;

        public InvokePlacingFactory(IConstructionGridManager constructionGridManager,
                                    IConstructionPreviewFactory constructionPreviewFactory,
                                    ICellsVisualization occupiedCellsVisualization,
                                    IBuildingStructureFactory structureFactory,
                                    IBuildingRotationController rotationController,
                                    IConstructionController constructionController)
        {
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _constructionPreviewFactory = constructionPreviewFactory ?? throw new ArgumentNullException(nameof(constructionPreviewFactory));
            _placmentCellsVisualization = occupiedCellsVisualization ?? throw new ArgumentNullException(nameof(occupiedCellsVisualization));
            _structureFactory = structureFactory ?? throw new ArgumentNullException(nameof(structureFactory));

            _rotationController = rotationController ?? throw new ArgumentNullException(nameof(rotationController));
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));
        }

        public Action CreateInvokePlacing(IConstructionConfiguration constructionConfiguration, Action<BuildingStructure> structurePlacedCallback)
        {
            PlacingState placing = new(constructionConfiguration,
                                       _constructionGridManager,
                                       _constructionPreviewFactory,
                                       _placmentCellsVisualization,
                                       _structureFactory,
                                       structurePlacedCallback);

            return InvokePlacing;

            void InvokePlacing()
            {
                _rotationController.ProvidePlacingState(placing);
                _constructionController.EnterState(placing);
            }
        }
    }
}