using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem.NoArguments
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event/No Arguments")]
    public class NoArgumentsGameEventSO : ScriptableObject
    {
        private readonly List<INoArgumentsGameEventListener> _listeners = new();

        public void AddListener(INoArgumentsGameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(INoArgumentsGameEventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Call()
        {
            foreach (var listener in _listeners)
            {
                listener.Notify();
            }
        }
    }
}