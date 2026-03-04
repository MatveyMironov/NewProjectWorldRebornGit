using UnityEngine;

namespace ManufactureSystem.Testing
{
    public abstract class ATestManufacturesMB : MonoBehaviour
    {
        [SerializeField] private SManufactureConfiguration[] manufactureConfigurations = new SManufactureConfiguration[0];

        protected abstract IManufacturesManager ManufacturesManager { get; }

        protected virtual void Start()
        {
            foreach (var configuration in manufactureConfigurations)
            {
                IManufacture manufacture = configuration.CreateManufacture();
                ManufacturesManager.TryAddManufacture(manufacture);
            }
        }
    }
}