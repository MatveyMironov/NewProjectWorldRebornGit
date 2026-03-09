using CustomInfoSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class EmptyTaskInfo : ICustomInfo
    {
        public GameObject CreateInfoObject()
        {
            return new GameObject();
        }
    }
}