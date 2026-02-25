using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class ServiceBalanceDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private AServiceBalanceDisplayerMB serviceBalanceDisplayer;
        [SerializeField] private ServiceDefinitionSO service;

        private void Start()
        {
            serviceBalanceDisplayer.DisplayServiceBalance(service);
        }
    }
}