using UnityEngine;

namespace ToggleSystem
{
    public abstract class ASwitchMB : MonoBehaviour, ISwitch
    {
        public abstract int StatesCount { get; }
        public abstract int CurrentStateIndex { get; }

        public abstract void Switch();
        public abstract void SwitchTo(int stateIndex);
        public abstract bool TrySwitchTo(int stateIndex);
    }
}