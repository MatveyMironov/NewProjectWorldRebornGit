using UnityEngine;

namespace ManufactureSystem.Testing
{
    public class TestManufacturesMB : ATestManufacturesMB
    {
        [SerializeField] private ManufacturesManagerMB manufacturesManager;

        protected override IManufacturesManager ManufacturesManager => manufacturesManager;
    }
}