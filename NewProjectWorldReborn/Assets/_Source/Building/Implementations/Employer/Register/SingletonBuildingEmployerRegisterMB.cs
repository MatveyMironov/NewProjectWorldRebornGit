using EmployerSystem;

namespace BuildingSystem.Implementations
{
    public class SingletonBuildingEmployerRegisterMB : ABuildingEmployerRegisterMB
    {
        protected override IStructureBuildingsManager BuildingsManager => throw new System.NotImplementedException();
        protected override IEmployersManager EmployersManager => throw new System.NotImplementedException();
    }
}