using BuildingViewSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public interface IConstructionConfiguration
    {
        BuildingViewMB BuildingViewPrefab { get; }

        Layout GetBuildingLayout();
        GameObject CreateBuildingPreviewObject();
    }
}