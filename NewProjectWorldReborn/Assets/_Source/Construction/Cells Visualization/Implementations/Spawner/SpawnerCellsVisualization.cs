using System;
using System.Collections.Generic;
using UnityEngine;

namespace CellsVisualizationSystem.Implementations
{
    public class SpawnerCellsVisualization : ICellsVisualization
    {
        private readonly Grid _grid;
        private readonly CellVisualizationMB _cellVisualizationPrefab;
        private readonly Transform _cellVisualizationsRoot;

        private readonly Dictionary<Vector2Int, CellVisualizationMB> _cellVisualizations = new();

        public SpawnerCellsVisualization(Grid grid, CellVisualizationMB cellVisualizationPrefab, Transform cellVisualizationRoot)
        {
            _grid = grid != null ? grid : throw new ArgumentNullException(nameof(grid));
            _cellVisualizationPrefab = cellVisualizationPrefab != null ? cellVisualizationPrefab : throw new ArgumentNullException(nameof(cellVisualizationPrefab));
            _cellVisualizationsRoot = cellVisualizationRoot != null ? cellVisualizationRoot : throw new ArgumentNullException(nameof(cellVisualizationRoot));
        }

        public void CreateVisualization(Vector2Int[] cells)
        {
            DestroyVisualization();

            foreach (Vector2Int cell in cells)
            {
                Vector3Int cellPosition = new(cell.x, 0, cell.y);
                Vector3 worldPosition = _grid.CellToWorld(cellPosition);

                CellVisualizationMB cellVisualization = UnityEngine.Object.Instantiate(_cellVisualizationPrefab, _cellVisualizationsRoot);
                cellVisualization.transform.position = worldPosition;
                cellVisualization.gameObject.SetActive(true);
                _cellVisualizations.Add(cell, cellVisualization);
            }
        }

        public void DestroyVisualization()
        {
            foreach (var cellVisualizer in _cellVisualizations.Values)
            {
                UnityEngine.Object.Destroy(cellVisualizer.gameObject);
            }

            _cellVisualizations.Clear();
        }
    }
}