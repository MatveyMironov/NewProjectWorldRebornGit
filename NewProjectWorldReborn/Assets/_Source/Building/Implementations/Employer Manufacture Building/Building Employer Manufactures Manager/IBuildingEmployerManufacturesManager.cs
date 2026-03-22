using EmployerManufactureSystem;
using System;

namespace BuildingSystem.Implementations
{
    public interface IBuildingEmployerManufacturesManager
    {
        Building[] Buildings { get; }

        event Action<Building> OnBuildingAdded;
        event Action<Building> OnBuildingRemoved;

        bool TryAddBuildingEmployerManufacture(Building building, IEmployerManufacture employerManufacture);
        bool TryRemoveBuildingEmployerManufacture(Building building);
        bool TryGetBuildingEmployerManufacture(Building building, out IEmployerManufacture employerManufacture);
    }
}