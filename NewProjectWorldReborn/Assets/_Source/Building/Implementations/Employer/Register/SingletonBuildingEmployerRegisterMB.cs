using EmployerSystem;

namespace BuildingSystem.Implementations
{
    public class SingletonBuildingEmployerRegisterMB : ABuildingEmployerRegisterMB
    {
        protected override IStructureBuildingsManager BuildingsManager { get; } = StructureBuildingsManagerSingleton.Instance;
        protected override IEmployersManager EmployersManager { get; } = EmployersManagerSingleton.Instance;
    }
}