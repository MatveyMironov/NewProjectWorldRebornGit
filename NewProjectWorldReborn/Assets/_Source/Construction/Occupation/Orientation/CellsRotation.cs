using System.Collections.Generic;
using UnityEngine;

namespace LayoutSystem
{
    internal static class CellsRotation
    {
        public static HashSet<Vector2Int> RotateCells(HashSet<Vector2Int> cells, EOrientation orientation)
        {
            HashSet<Vector2Int> rotatedCells = new();

            switch (orientation)
            {
                case EOrientation.up:
                rotatedCells = RotateCellsUp(cells);
                break;

                case EOrientation.right:
                rotatedCells = RotateCellsRight(cells);
                break;

                case EOrientation.down:
                rotatedCells = RotateCellsDown(cells);
                break;

                case EOrientation.left:
                rotatedCells = RotateCellsLeft(cells);
                break;
            }

            return rotatedCells;
        }

        public static HashSet<Vector2Int> RotateCellsUp(HashSet<Vector2Int> cells)
        {
            HashSet<Vector2Int> rotatedCells = new();

            rotatedCells.UnionWith(cells);

            return rotatedCells;
        }

        public static HashSet<Vector2Int> RotateCellsRight(HashSet<Vector2Int> cells)
        {
            HashSet<Vector2Int> rotatedCells = new();

            foreach (var cell in cells)
            {
                Vector2Int rotatedCell = new(cell.y, -cell.x);

                rotatedCells.Add(rotatedCell);
            }

            return rotatedCells;
        }

        public static HashSet<Vector2Int> RotateCellsDown(HashSet<Vector2Int> cells)
        {
            HashSet<Vector2Int> rotatedCells = new();

            foreach (var cell in cells)
            {
                Vector2Int rotatedCell = new(-cell.x, -cell.y);

                rotatedCells.Add(rotatedCell);
            }

            return rotatedCells;
        }

        public static HashSet<Vector2Int> RotateCellsLeft(HashSet<Vector2Int> cells)
        {
            HashSet<Vector2Int> rotatedCells = new();

            foreach (var cell in cells)
            {
                Vector2Int rotatedCell = new(-cell.y, cell.x);

                rotatedCells.Add(rotatedCell);
            }

            return rotatedCells;
        }
    }
}
