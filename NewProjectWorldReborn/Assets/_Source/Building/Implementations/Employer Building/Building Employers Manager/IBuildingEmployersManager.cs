using EmployerSystem;
using System;

namespace BuildingSystem.Implementations
{
    public interface IBuildingEmployersManager
    {
        Building[] Buildings { get; }

        event Action<Building> OnBuildingAdded;
        event Action<Building> OnBuildingRemoved;

        bool TryAddBuildingEmployer(Building building, IEmployer employer);
        bool TryRemoveBuildingEmployer(Building building);
        bool TryGetBuildingEmployer(Building building, out IEmployer employer);
    }
}