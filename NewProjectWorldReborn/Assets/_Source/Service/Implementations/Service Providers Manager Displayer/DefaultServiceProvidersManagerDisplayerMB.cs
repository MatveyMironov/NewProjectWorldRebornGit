using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class DefaultServiceProvidersManagerDisplayerMB : AServiceProvidersManagerDisplayer
    {
        [SerializeField] private ServiceProviderDisplayersManagerMB serviceProviderDisplayersManager;

        private IServiceProvidersManager _displayedManager;

        private void OnDestroy()
        {
            Clear();
        }

        public override void DisplayServiceProvidersManager(IServiceProvidersManager manager)
        {
            Clear();

            foreach (var provider in manager.Providers)
            {
                DisplayServiceProvider(provider);
            }

            manager.OnServiceProviderAdded += DisplayServiceProvider;
            manager.OnServiceProviderRemoved += HideServiceProvider;

            _displayedManager = manager;
        }

        public override void Clear()
        {
            if (_displayedManager == null) return;

            _displayedManager.OnServiceProviderAdded -= DisplayServiceProvider;
            _displayedManager.OnServiceProviderRemoved -= HideServiceProvider;

            serviceProviderDisplayersManager.RemoveAllDisplayers();

            _displayedManager = null;
        }

        private void DisplayServiceProvider(ServiceProvider provider)
        {
            serviceProviderDisplayersManager.TryAddDisplayer(provider);
        }

        private void HideServiceProvider(ServiceProvider provider)
        {
            serviceProviderDisplayersManager.TryRemoveDisplayer(provider);
        }
    }
}