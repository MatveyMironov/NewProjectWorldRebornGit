using System.Collections.Generic;
using UnityEngine;

namespace ConstructionGridSystem
{
    public class ConstructionGridManager : IConstructionGridManager
    {
        private readonly ConstructionGrid _constructionGrid;

        private readonly Dictionary<ConstructedBuilding, Vector2Int> _buildingOriginCells = new();

        public ConstructionGridManager(ConstructionGrid constructionGrid)
        {
            _constructionGrid = constructionGrid ?? throw new System.ArgumentNullException(nameof(constructionGrid));
        }

        public HashSet<Vector2Int> Cells => _constructionGrid.Cells;

        public void RemoveBuilding(ConstructedBuilding building)
        {
            if (_buildingOriginCells.Remove(building, out var originCell))
            {
                RemoveBuilding(originCell);
            }
        }

        public bool TryPlaceBuilding(ConstructedBuilding building, Vector2Int originCell)
        {
            if (!_buildingOriginCells.ContainsKey(building))
            {
                if (_constructionGrid.TryPlaceBuilding(building, originCell))
                {
                    _buildingOriginCells.Add(building, originCell);
                    return true;
                }
            }

            return false;
        }

        public void RemoveBuilding(Vector2Int cell)
        {
            _constructionGrid.RemoveBuilding(cell);
        }

        public bool CheckIfCanPlaceBuilding(Vector2Int originCell, HashSet<Vector2Int> layoutCells)
        {
            return _constructionGrid.CheckIfCanPlaceBuilding(originCell, layoutCells);
        }

        public bool TryGetBuilding(Vector2Int cell, out ConstructedBuilding building)
        {
            return _constructionGrid.TryGetBuilding(cell, out building);
        }

        public HashSet<ConstructedBuilding> GetAllBuildingsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            HashSet<Vector2Int> cells = GetAllCellsFromTo(firstCell, secondCell);
            return GetAllBuildingsIn(cells);
        }

        public HashSet<ConstructedBuilding> GetAllBuildingsIn(HashSet<Vector2Int> cells)
        {
            HashSet<ConstructedBuilding> buildings = new();

            foreach (var cell in cells)
            {
                if (_constructionGrid.TryGetBuilding(cell, out ConstructedBuilding building))
                {
                    buildings.Add(building);
                }
            }

            return buildings;
        }

        public HashSet<Vector2Int> GetAllCellsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            HashSet<Vector2Int> cells = new();

            Vector2Int lowerLeftCorner = Vector2Int.zero;
            Vector2Int upperRightCorner = Vector2Int.zero;

            if (firstCell.x <= secondCell.x)
            {
                lowerLeftCorner.x = firstCell.x;
                upperRightCorner.x = secondCell.x;
            }
            else
            {
                lowerLeftCorner.x = secondCell.x;
                upperRightCorner.x = firstCell.x;
            }

            if (firstCell.y <= secondCell.y)
            {
                lowerLeftCorner.y = firstCell.y;
                upperRightCorner.y = secondCell.y;
            }
            else
            {
                lowerLeftCorner.y = secondCell.y;
                upperRightCorner.y = firstCell.y;
            }

            HashSet<Vector2Int> validCells = _constructionGrid.Cells;

            for (int x = lowerLeftCorner.x; x <= upperRightCorner.x; x++)
            {
                for (int y = lowerLeftCorner.y; y <= upperRightCorner.y; y++)
                {
                    Vector2Int cell = new(x, y);
                    if (validCells.Contains(cell))
                    {
                        cells.Add(cell);
                    }
                }
            }

            return cells;
        }
    }
}