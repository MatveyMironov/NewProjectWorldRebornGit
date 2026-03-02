using System.Collections.Generic;
using UnityEngine;

namespace ConstructionGridSystem
{
    public class ConstructionGridManager : IConstructionGridManager
    {
        private readonly ConstructionGrid _constructionGrid;

        private readonly Dictionary<BuildingStructure, Vector2Int> _buildingOriginCells = new();

        public ConstructionGridManager(ConstructionGrid constructionGrid)
        {
            _constructionGrid = constructionGrid ?? throw new System.ArgumentNullException(nameof(constructionGrid));
        }

        public HashSet<Vector2Int> Cells => _constructionGrid.Cells;

        public void RemoveStructure(BuildingStructure building)
        {
            if (_buildingOriginCells.Remove(building, out var originCell))
            {
                RemoveStructureFrom(originCell);
            }
        }

        public bool TryPlaceStructureAt(BuildingStructure building, Vector2Int originCell)
        {
            if (!_buildingOriginCells.ContainsKey(building))
            {
                if (_constructionGrid.TryPlaceStructure(building, originCell))
                {
                    _buildingOriginCells.Add(building, originCell);
                    return true;
                }
            }

            return false;
        }

        public void RemoveStructureFrom(Vector2Int cell)
        {
            _constructionGrid.RemoveStructure(cell);
        }

        public bool CheckIfCanPlaceLayoutAt(Vector2Int originCell, HashSet<Vector2Int> layoutCells)
        {
            return _constructionGrid.CheckIfCanPlaceStructure(originCell, layoutCells);
        }

        public bool TryGetPlacementAt(Vector2Int cell, out ConstructionGrid.PlacementData placement)
        {
            return _constructionGrid.TryGetStructure(cell, out placement);
        }

        public HashSet<ConstructionGrid.PlacementData> GetAllStructuresFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            HashSet<Vector2Int> cells = GetAllCellsFromTo(firstCell, secondCell);
            return GetAllStructuresIn(cells);
        }

        public HashSet<ConstructionGrid.PlacementData> GetAllStructuresIn(HashSet<Vector2Int> cells)
        {
            HashSet<ConstructionGrid.PlacementData> placments = new();

            foreach (var cell in cells)
            {
                if (_constructionGrid.TryGetStructure(cell, out ConstructionGrid.PlacementData placement))
                {
                    placments.Add(placement);
                }
            }

            return placments;
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