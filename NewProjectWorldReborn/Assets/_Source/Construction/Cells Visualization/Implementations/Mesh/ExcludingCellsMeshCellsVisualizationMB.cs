using UnityEngine;

namespace CellsVisualizationSystem.Implementations
{
    public class ExcludingCellsMeshCellsVisualizationMB : DefaultMeshCellsVisualizationMB
    {
        [Space]
        [SerializeField] private ExcludedCellsMeshCellsVisualizationMB excludedCellsMeshCellsVisualization;

        public override void CreateVisualization(Vector2Int[] cells)
        {
            base.CreateVisualization(cells);

            excludedCellsMeshCellsVisualization.ExcludeCells(cells);
        }

        public override void DestroyVisualization()
        {
            base.DestroyVisualization();

            excludedCellsMeshCellsVisualization.ExcludeCells(new Vector2Int[0]);
        }
    }
}
