using UnityEngine;
using UnityEngine.Events;

namespace SwitchSystem
{
    public class UnityEventSwitchMB : ASwitchMB
    {
        [SerializeField] private UnityEvent[] States = new UnityEvent[0];

        private int _currentStateIndex = -1;

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
            if (stateIndex == _currentStateIndex) return false;
            
            if (stateIndex >= 0 && stateIndex < States.Length)
            {
                _currentStateIndex = stateIndex;
                States[_currentStateIndex].Invoke();
                return true;
            }

            return false;
        }
    }
}