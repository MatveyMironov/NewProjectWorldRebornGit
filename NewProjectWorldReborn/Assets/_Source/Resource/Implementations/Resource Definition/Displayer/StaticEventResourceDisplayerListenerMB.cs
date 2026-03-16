using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class StaticEventResourceDisplayerListenerMB : MonoBehaviour
    {
        [SerializeField] private AResourceDisplayerMB resourceDisplayer;

        private void Awake()
        {
            StaticEventResourceDisplayerMB.OnResourceDisplayed += resourceDisplayer.DisplayResource;
            StaticEventResourceDisplayerMB.OnCleared += resourceDisplayer.Clear;
        }

        private void OnDestroy()
        {
            StaticEventResourceDisplayerMB.OnResourceDisplayed -= resourceDisplayer.DisplayResource;
            StaticEventResourceDisplayerMB.OnCleared -= resourceDisplayer.Clear;
        }
    }
}