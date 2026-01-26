using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ManufactureSystem.Implementations
{
    public class ManufactureResourcesDisplayer : IManufactureResourcesDisplayer
    {
        private readonly IResourceCountDisplayersManager _consumedResourcesDisplayer;
        private readonly IResourceCountDisplayersManager _producedResourcesDisplayer;

        public ManufactureResourcesDisplayer(IResourceCountDisplayersManager consumedResourcesDisplayer, IResourceCountDisplayersManager producedResourcesDisplayer)
        {
            _consumedResourcesDisplayer = consumedResourcesDisplayer ?? throw new ArgumentNullException(nameof(consumedResourcesDisplayer));
            _producedResourcesDisplayer = producedResourcesDisplayer ?? throw new ArgumentNullException(nameof(producedResourcesDisplayer));
        }

        public void DisplayManufacture(IManufacture manufacture)
        {
            DisplayConsumedResources(manufacture.ConsumedResources);
            DisplayProducedResources(manufacture.ProducedResources);
        }

        public void Clear()
        {
            HideConsumedResources();
            HideProducedResources();

            void HideConsumedResources()
            {
                _consumedResourcesDisplayer.Clear();
            }

            void HideProducedResources()
            {
                _producedResourcesDisplayer.Clear();
            }
        }

        private void DisplayConsumedResources(in Dictionary<IResourceDefinition, int> resources)
        {
            DisplayResources(resources, _consumedResourcesDisplayer);
        }

        private void DisplayProducedResources(in Dictionary<IResourceDefinition, int> resources)
        {
            DisplayResources(resources, _producedResourcesDisplayer);
        }

        private void DisplayResources(in Dictionary<IResourceDefinition, int> resources, IResourceCountDisplayersManager resourcesDisplayer)
        {
            foreach (var resource in resources)
            {
                resourcesDisplayer.DisplayResourceCount(resource.Key, resource.Value);
            }
        }
    }
}