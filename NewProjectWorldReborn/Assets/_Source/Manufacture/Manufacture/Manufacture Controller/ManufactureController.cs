using System.Collections.Generic;

namespace ManufactureSystem
{
    public class ManufactureController : IManufactureController
    {
        private readonly HashSet<IManufacture> _manufactures = new();

        public bool TryAddManufacture(IManufacture manufacture)
        {
            if (_manufactures.Add(manufacture))
            {
                manufacture.StartManufacture();
                return true;
            }

            return false;
        }

        public bool TryRemoveManufacture(IManufacture manufacture)
        {
            if (_manufactures.Remove(manufacture))
            {
                manufacture.AbortManufacture();
                return true;
            }

            return false;
        }

        public void Update()
        {
            foreach (var manufacture in _manufactures)
            {
                manufacture.ProgressManufacture();
            }
        }
    }
}