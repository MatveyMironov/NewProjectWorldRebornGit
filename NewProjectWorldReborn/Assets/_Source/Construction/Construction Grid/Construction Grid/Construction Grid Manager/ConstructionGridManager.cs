using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ConstructionGridSystem
{
    public class ConstructionGridManager : IConstructionGridManager
    {
        private readonly ConstructionGrid _constructionGrid;

        private readonly Dictionary<BuildingStructure, Vector2Int> _structures_OriginCells = new();
        private readonly Dictionary<BuildingStructure, ConstructionGrid.PlacementData> _structures_Placements = new();

        public ConstructionGridManager(ConstructionGrid constructionGrid)
        {
            _constructionGrid = constructionGrid ?? throw new System.ArgumentNullException(nameof(constructionGrid));
        }

        public HashSet<Vector2Int> Cells => _constructionGrid.Cells;

        public bool TryRemoveStructure(BuildingStructure structure)
        {
            //if (_structures_OriginCells.Remove(structure, out var originCell))
            //{
            //    RemoveStructureAt(originCell);
            //}

            if (_structures_Placements.Remove(structure, out var placement))
            {
                return _constructionGrid.TryRemoveStructureAt(placement.OccupiedCells.ToArray()[0], out _);
            }

            return false;
        }

        public bool TryPlaceStructureAt(BuildingStructure structure, Vector2Int originCell)
        {
            //if (!_structures_OriginCells.ContainsKey(structure))
            //{
            //    if (_constructionGrid.TryPlaceStructureAt(structure, originCell))
            //    {
            //        _structures_OriginCells.Add(structure, originCell);
            //        return true;
            //    }
            //}

            //return false;

            if (!_structures_OriginCells.ContainsKey(structure))
            {
                if (_constructionGrid.TryPlaceStructureAt(structure, originCell, out ConstructionGrid.PlacementData placement))
                {
                    _structures_Placements.Add(structure, placement);
                    return true;
                }
            }

            return false;
        }

        public bool TryRemoveStructureAt(Vector2Int cell)
        {
            if (_constructionGrid.TryRemoveStructureAt(cell, out ConstructionGrid.PlacementData placement))
            {
                _structures_Placements.Remove(placement.Structure);
                return true;
            }

            return false;
        }

        public bool CheckIfCanPlaceLayoutAt(Vector2Int originCell, HashSet<Vector2Int> layoutCells)
        {
            return _constructionGrid.CheckIfCanPlaceLayoutAt(originCell, layoutCells);
        }

        public bool TryGetPlacementAt(Vector2Int cell, out ConstructionGrid.PlacementData placement)
        {
            return _constructionGrid.TryGetPlacementAt(cell, out placement);
        }

        public HashSet<ConstructionGrid.PlacementData> GetAllPlacementsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            return GetAllPlacementsIn(GetAllCellsFromTo(firstCell, secondCell));
        }

        public HashSet<ConstructionGrid.PlacementData> GetAllPlacementsIn(HashSet<Vector2Int> cells)
        {
            HashSet<ConstructionGrid.PlacementData> placments = new();

            foreach (var cell in cells)
            {
                if (_constructionGrid.TryGetPlacementAt(cell, out ConstructionGrid.PlacementData placement))
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