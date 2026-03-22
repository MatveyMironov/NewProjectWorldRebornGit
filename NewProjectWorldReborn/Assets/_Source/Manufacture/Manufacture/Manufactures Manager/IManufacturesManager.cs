using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    public interface IManufacturesManager
    {
        HashSet<IManufacture> Manufactures { get; }
        event Action<IManufacture> OnManufactureAdded;
        event Action<IManufacture> OnManufactureRemoved;

        bool TryAddManufacture(IManufacture manufacture);
        bool TryRemoveManufacture(IManufacture manufacture);
    }
}