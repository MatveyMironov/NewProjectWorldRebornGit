using ConstructionGridSystem;
using UnityEngine;

namespace ConstructionSystem
{
    public abstract class AStructureDisplayerMB : MonoBehaviour
    {
        public abstract void DisplayStructure(BuildingStructure structure);
        public abstract void HideStructure();
    }
}