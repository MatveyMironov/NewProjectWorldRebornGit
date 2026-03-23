using HidableSystem;
using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class HidableServiceProviderDisplayerMB : AServiceProviderDisplayerMB
    {
        [SerializeField] private AServiceProviderDisplayerMB actualDisplayer;
        [SerializeField] private AHidableMB hidable;

        public override void DisplayServiceProvider(ServiceProvider serviceProvider)
        {
            actualDisplayer.DisplayServiceProvider(serviceProvider);
            hidable.Show();
        }

        public override void Clear()
        {
            actualDisplayer.Clear();
            hidable.Hide();
        }
    }
}