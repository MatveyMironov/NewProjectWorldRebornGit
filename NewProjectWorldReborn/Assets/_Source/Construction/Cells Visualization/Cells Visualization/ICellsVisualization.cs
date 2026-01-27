using UnityEngine;

namespace CellsVisualizationSystem
{
    public interface ICellsVisualization
    {
        public void CreateVisualization(Vector2Int[] cells);
        public void DestroyVisualization();
    }
}
