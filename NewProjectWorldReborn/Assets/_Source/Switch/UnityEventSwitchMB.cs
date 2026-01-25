using UnityEngine;
using UnityEngine.Events;

namespace ToggleSystem
{
    public class UnityEventSwitchMB : ASwitchMB
    {
        [SerializeField] private UnityEvent[] States = new UnityEvent[0];

        private int _currentStateIndex;

        public override int StatesCount => States.Length;
        public override int CurrentStateIndex => _currentStateIndex;

        private void Start()
        {
            TrySwitchTo(0);
        }

        public override void Switch()
        {
            _currentStateIndex = (_currentStateIndex + 1 < StatesCount) ? (_currentStateIndex + 1) : 0;
            States[_currentStateIndex].Invoke();
        }

        public override void SwitchTo(int stateIndex)
        {
            TrySwitchTo(stateIndex);
        }

        public override bool TrySwitchTo(int stateIndex)
        {
            if (stateIndex >= 0 && stateIndex < States.Length)
            {
                States[stateIndex].Invoke();
                _currentStateIndex = stateIndex;
                return true;
            }

            return false;
        }
    }
}