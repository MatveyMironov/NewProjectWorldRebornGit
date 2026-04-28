using UnityEngine;
using UnityEngine.Events;

public class StartUnityEventMB : MonoBehaviour
{
    [SerializeField] private UnityEvent startEvent;

    private void Start()
    {
        startEvent.Invoke();
    }
}