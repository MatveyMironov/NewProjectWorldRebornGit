using System;
using System.Collections.Generic;
using UnityEngine;

namespace LayoutSystem
{
    public class Layout
    {
        private readonly HashSet<Vector2Int> _baseCells;

        public Layout(HashSet<Vector2Int> baseCells)
        {
            _baseCells = baseCells ?? throw new ArgumentNullException(nameof(baseCells));
        }

        public EOrientation Orientation { get; set; } = EOrientation.up;
        public HashSet<Vector2Int> OccupiedCells => CellsRotation.RotateCells(_baseCells, Orientation);
    }
}