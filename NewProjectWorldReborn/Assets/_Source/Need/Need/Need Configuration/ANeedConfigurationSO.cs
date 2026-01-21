using UnityEngine;

namespace NeedSystem
{
    public abstract class ANeedConfigurationSO : ScriptableObject, INeedConfiguration
    {
        public abstract INeed CreateNeed();
    }
}