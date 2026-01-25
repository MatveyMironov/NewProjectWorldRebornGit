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

            Setup();

            void Setup()
            {
                foreach (var cell in cells)
                {
                    _cellsData.Add(cell, null);
                }
            }
        }

        public HashSet<Vector2Int> Cells => new(_cellsData.Keys);

        public bool TryPlaceBuilding(ConstructedBuilding building, Vector2Int cell)
        {
            HashSet<Vector2Int> cellsToOccupy = CalculateCellsToOccupy(cell, building.OccupiedCells);

            if (CheckIfCanOccupyCells(cellsToOccupy))
            {
                OccupyCellsWithBuilding(cellsToOccupy, building);

                return true;
            }

            return false;
        }

        public void RemoveBuilding(Vector2Int cell)
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

        public bool CheckIfCanPlaceBuilding(Vector2Int cell, HashSet<Vector2Int> layoutCells)
        {
            HashSet<Vector2Int> cellsToOccupy = CalculateCellsToOccupy(cell, layoutCells);
            return CheckIfCanOccupyCells(cellsToOccupy);
        }

        public bool TryGetBuilding(Vector2Int cell, out ConstructedBuilding building)
        {
            if (_cellsData.TryGetValue(cell, out PlacementData placement))
            {
                if (placement != null)
                {
                    building = placement.Building;
                    return true;
                }
            }

            building = null;
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

        private void OccupyCellsWithBuilding(HashSet<Vector2Int> cellsToOccupy, ConstructedBuilding building)
        {
            PlacementData placement = new(building, cellsToOccupy);

            foreach (var cell in cellsToOccupy)
            {
                _cellsData[cell] = placement;
            }
        }

        private class PlacementData
        {
            public readonly ConstructedBuilding Building;
            public readonly HashSet<Vector2Int> OccupiedCells;

            public PlacementData(ConstructedBuilding building, HashSet<Vector2Int> occupiedCells)
            {
                Building = building ?? throw new ArgumentNullException(nameof(building));
                OccupiedCells = occupiedCells ?? throw new ArgumentNullException(nameof(occupiedCells));
            }
        }
    }
}