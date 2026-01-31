using ConstructionGridSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public class BuildingViewInstantiatorMB : MonoBehaviour, IBuildingStructureCreator
    {
        [SerializeField] private Transform buildingViewsParent;
        [SerializeField] private Grid grid;

        public BuildingStructure CreateBuildingStructure(IConstructionConfiguration constructionConfiguration, Vector2Int cell, EOrientation orientation)
        {
            BuildingStructure structure = constructionConfiguration.CreateBuildingStructure();
            structure.View.transform.SetParent(buildingViewsParent);

            Vector3Int cellPosition = new(cell.x, 0, cell.y);
            Vector3 worldPosition = grid.CellToWorld(cellPosition) + grid.cellSize / 2;
            structure.View.transform.position = worldPosition;

            structure.Layout.Orientation = orientation;

            switch (orientation)
            {
                case EOrientation.up:
                structure.View.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;

                case EOrientation.right:
                structure.View.transform.localRotation = Quaternion.Euler(0, 90, 0);
                break;

                case EOrientation.down:
                structure.View.transform.localRotation = Quaternion.Euler(0, 180, 0);
                break;

                case EOrientation.left:
                structure.View.transform.localRotation = Quaternion.Euler(0, 270, 0);
                break;
            }

            return structure;
        }
    }
}