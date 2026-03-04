using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public class ManufacturesManagerDisplayerSetuperMB : AManufacturesManagerDisplayerSetuperMB
    {
        [SerializeField] private ManufacturesManagerMB manufacturesManager;

        protected override IManufacturesManager ManufacturesManager => manufacturesManager;
    }
}