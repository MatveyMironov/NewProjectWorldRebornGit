using UnityEngine;

namespace NeedSystem
{
    public abstract class ANeedDisplayerMB : MonoBehaviour, INeedDisplayer
    {
        public abstract void DisplayNeed(INeed need);
        public abstract void Clear();
    }
}