using UnityEngine;

namespace CellsVisualizationSystem.Implementations
{
    public class SpawnerCellsVisualizationMB : ACellsVisualizationMB
    {
        [SerializeField] private Grid grid;
        [SerializeField] private CellVisualizationMB cellVisualizationPrefab;
        [SerializeField] private Transform cellVisualizersRoot;

        private ICellsVisualization _cellsVisualization;

        private void Awake()
        {
            _cellsVisualization = new SpawnerCellsVisualization(grid, cellVisualizationPrefab, cellVisualizersRoot);
        }

        public override void CreateVisualization(Vector2Int[] cells)
        {
            _cellsVisualization.CreateVisualization(cells);
        }

        public override void DestroyVisualization()
        {
            _cellsVisualization.DestroyVisualization();
        }
    }
}