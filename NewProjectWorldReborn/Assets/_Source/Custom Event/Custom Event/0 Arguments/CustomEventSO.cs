using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomEventSystem
{
    [CreateAssetMenu(fileName = "New Custom Event", menuName = "Custom Event")]
    public class CustomEventSO : ScriptableObject, ICustomEvent
    {
        private readonly HashSet<Action> _listeners = new();

        public void AddListener(Action listener)
        {
            if (listener == null) return;

            _listeners.Add(listener);
        }

        public void RemoveListener(Action listener)
        {
            if (listener == null) return;

            _listeners.Remove(listener);
        }

        public void Call()
        {
            foreach (var listener in _listeners)
            {
                listener.Invoke();
            }
        }
    }
}