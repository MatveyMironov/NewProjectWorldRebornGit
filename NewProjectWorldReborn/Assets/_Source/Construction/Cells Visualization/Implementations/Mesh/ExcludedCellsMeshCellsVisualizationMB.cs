using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CellsVisualizationSystem.Implementations
{
    public class ExcludedCellsMeshCellsVisualizationMB : AMeshCellsVisualizationMB
    {
        private Vector2Int[] _excludedCells = new Vector2Int[0];

        protected override InstanceData[] RenderedInstances { get => GetRenderedInstances(); }

        private InstanceData[] GetRenderedInstances()
        {
            Dictionary<Vector2Int, InstanceData> culledInstances = new(CulledInstances);

            foreach (var cell in _excludedCells)
            {
                culledInstances.Remove(cell);
            }

            return culledInstances.Values.ToArray();
        }

        public void ExcludeCells(Vector2Int[] cells)
        {
            if (cells == null) return;

            _excludedCells = cells;
        }
    }
}
