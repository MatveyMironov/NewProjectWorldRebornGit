using UnityEngine;

namespace ManufactureSystem.Implementations
{
    public abstract class AManufacturesManagerDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private AManufacturesManagerDisplayerMB manufacturesManagerDisplayer;

        protected abstract IManufacturesManager ManufacturesManager { get; }

        protected virtual void Start()
        {
            manufacturesManagerDisplayer.DisplayManufacturesManager(ManufacturesManager);
        }
    }
}