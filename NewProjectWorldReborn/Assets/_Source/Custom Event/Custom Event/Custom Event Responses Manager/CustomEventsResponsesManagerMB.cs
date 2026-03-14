using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace CustomEventSystem
{
    public class CustomEventsResponsesManagerMB : MonoBehaviour
    {
        [SerializeField] private CustomEventsResponses[] EventsResponses = new CustomEventsResponses[0];

        private readonly Dictionary<UnityEvent, List<CustomEventSO>> RegisteredEventsResponses = new();

        private void Awake()
        {
            foreach (var eventsResponse in EventsResponses)
            {
                RegisteredEventsResponses.Add(eventsResponse.Response, new());

                foreach (var customEvent in eventsResponse.CustomEvents)
                {
                    customEvent.AddListener(eventsResponse.Response.Invoke);
                    RegisteredEventsResponses[eventsResponse.Response].Add(customEvent);
                }
            }
        }

        private void OnDestroy()
        {
            foreach (var response in RegisteredEventsResponses.Keys.ToArray())
            {
                foreach (var customEvent in RegisteredEventsResponses[response])
                {
                    customEvent.RemoveListener(response.Invoke);
                }

                RegisteredEventsResponses.Remove(response);
            }
        }

        [Serializable]
        private class CustomEventsResponses
        {
            [SerializeField] private CustomEventSO[] customEvents = new CustomEventSO[0];
            [SerializeField] private UnityEvent response;

            public CustomEventSO[] CustomEvents => customEvents.ToArray();
            public UnityEvent Response => response;
        }
    }
}