using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public class ManufactureDisplayerMB : AManufactureDisplayerMB
    {
        [SerializeField] private ManufactureResourcesDisplayerMB resourcesDisplayer;
        [SerializeField] private ManufactureProgressDisplayerMB progressDisplayer;
        [SerializeField] private ManufacturePauseControllerMB pauseController;

        public override void DisplayManufacture(IManufacture manufacture)
        {
            Clear();

            resourcesDisplayer.DisplayManufacture(manufacture);
            progressDisplayer.DisplayManufacture(manufacture);
            pauseController.ControlManufacture(manufacture);
        }

        public override void Clear()
        {
            resourcesDisplayer.Clear();
            progressDisplayer.Clear();
            pauseController.ReleaseManufacture();
        }
    }
}