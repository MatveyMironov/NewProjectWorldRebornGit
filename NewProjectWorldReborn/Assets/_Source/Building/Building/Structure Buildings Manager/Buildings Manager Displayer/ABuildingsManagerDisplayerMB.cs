using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingsManagerDisplayerMB : MonoBehaviour, IBuildingsManagerDisplayer
    {
        public abstract void DisplayBuildingsManager(IStructureBuildingsManager manager);
        public abstract void Clear();
    }
}