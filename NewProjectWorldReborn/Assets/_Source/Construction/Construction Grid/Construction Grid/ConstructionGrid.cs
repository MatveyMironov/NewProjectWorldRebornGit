using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionGridSystem
{
    public class ConstructionGrid
    {
        private readonly Dictionary<Vector2Int, PlacementData> _cellsData = new();

        public ConstructionGrid(HashSet<Vector2Int> cells)
        {
            if (cells == null) throw new ArgumentNullException(nameof(cells));

            foreach (var cell in cells)
            {
                _cellsData.Add(cell, null);
            }
        }

        public HashSet<Vector2Int> Cells => new(_cellsData.Keys);

        public bool TryPlaceStructure(BuildingStructure structure, Vector2Int cell)
        {
            HashSet<Vector2Int> cellsToOccupy = CalculateCellsToOccupy(cell, structure.Layout.OccupiedCells);

            if (CheckIfCanOccupyCells(cellsToOccupy))
            {
                OccupyCellsWithStructure(cellsToOccupy, structure);
                return true;
            }

            return false;
        }

        public void RemoveStructure(Vector2Int cell)
        {
            if (_cellsData.TryGetValue(cell, out PlacementData placement))
            {
                if (placement != null)
                {
                    foreach (var occupiedCell in placement.OccupiedCells)
                    {
                        _cellsData[occupiedCell] = null;
                    }
                }
            }
        }

        public bool CheckIfCanPlaceStructure(Vector2Int cell, HashSet<Vector2Int> layoutCells)
        {
            HashSet<Vector2Int> cellsToOccupy = CalculateCellsToOccupy(cell, layoutCells);
            return CheckIfCanOccupyCells(cellsToOccupy);
        }

        public bool TryGetStructure(Vector2Int cell, out PlacementData placement)
        {
            if (_cellsData.TryGetValue(cell, out placement))
            {
                if (placement != null) return true;
            }

            return false;
        }

        private HashSet<Vector2Int> CalculateCellsToOccupy(Vector2Int originCell, HashSet<Vector2Int> layoutCells)
        {
            HashSet<Vector2Int> cellsToOccupy = new();

            foreach (var cell in layoutCells)
            {
                cellsToOccupy.Add(originCell + cell);
            }

            return cellsToOccupy;
        }

        private bool CheckIfCanOccupyCells(HashSet<Vector2Int> cellsToOccupy)
        {
            foreach (var cell in cellsToOccupy)
            {
                if (CheckIfCellIsOccupiedOrNonExistent(cell))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfCellIsOccupiedOrNonExistent(Vector2Int cell)
        {
            if (_cellsData.TryGetValue(cell, out PlacementData placement))
            {
                return placement != null;
            }

            return true;
        }

        private void OccupyCellsWithStructure(HashSet<Vector2Int> cellsToOccupy, BuildingStructure structure)
        {
            PlacementData placement = new(structure, cellsToOccupy);

            foreach (var cell in cellsToOccupy)
            {
                _cellsData[cell] = placement;
            }
        }

        public class PlacementData
        {
            public readonly BuildingStructure Structure;
            public readonly HashSet<Vector2Int> OccupiedCells;

            public PlacementData(BuildingStructure structure, HashSet<Vector2Int> occupiedCells)
            {
                Structure = structure ?? throw new ArgumentNullException(nameof(structure));
                OccupiedCells = occupiedCells ?? throw new ArgumentNullException(nameof(occupiedCells));
            }
        }
    }
}