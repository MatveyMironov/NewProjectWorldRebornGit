using BuildingViewSystem;
using ConstructionGridSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public class BuildingStructureFactoryMB : MonoBehaviour, IBuildingStructureFactory
    {
        [SerializeField] private Transform buildingViewsParent;
        [SerializeField] private Grid grid;

        public BuildingStructure CreateBuildingStructure(Vector2Int cell, Layout layout, BuildingViewMB viewPrefab)
        {
            BuildingViewMB view = Instantiate(viewPrefab, buildingViewsParent);

            Vector3Int cellPosition = new(cell.x, 0, cell.y);
            Vector3 worldPosition = grid.CellToWorld(cellPosition) + grid.cellSize / 2;
            view.transform.position = worldPosition;

            switch (layout.Orientation)
            {
                case EOrientation.up:
                view.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;

                case EOrientation.right:
                view.transform.localRotation = Quaternion.Euler(0, 90, 0);
                break;

                case EOrientation.down:
                view.transform.localRotation = Quaternion.Euler(0, 180, 0);
                break;

                case EOrientation.left:
                view.transform.localRotation = Quaternion.Euler(0, 270, 0);
                break;
            }

            return new(view, layout);
        }
    }
}