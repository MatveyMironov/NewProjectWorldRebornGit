using BuildingViewSystem;
using LayoutSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionGridSystem
{
    public class ConstructedBuilding
    {
        public ConstructedBuilding(BuildingViewMB view, Layout layout)
        {
            View = view != null ? view : throw new ArgumentNullException(nameof(view));
            Layout = layout ?? throw new ArgumentNullException(nameof(layout));
        }

        public BuildingViewMB View { get; }
        public Layout Layout { get; }
        public HashSet<Vector2Int> OccupiedCells { get => Layout.OccupiedCells; }
    }
}