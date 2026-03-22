using ResourceSystem;
using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public class ManufactureResourcesDisplayerMB : MonoBehaviour, IManufactureResourcesDisplayer
    {
        [SerializeField] private AResourceCountDisplayersManagerMB consumedResourcesDisplayer;
        [SerializeField] private AResourceCountDisplayersManagerMB producedResourcesDisplayer;

        private IManufactureResourcesDisplayer _displayer;

        private void Awake()
        {
            _displayer = new ManufactureResourcesDisplayer(consumedResourcesDisplayer, producedResourcesDisplayer);
        }

        public void DisplayManufacture(IManufacture manufacture)
        {
            _displayer.DisplayManufacture(manufacture);
        }

        public void Clear()
        {
            _displayer.Clear();
        }
    }
}