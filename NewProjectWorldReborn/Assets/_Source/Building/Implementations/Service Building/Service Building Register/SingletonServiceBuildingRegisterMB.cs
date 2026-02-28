
namespace BuildingSystem.Implementations
{
    public class SingletonServiceBuildingRegisterMB : AServiceBuildingRegisterMB
    {
        protected override IServiceBuildingsManager ServiceBuildingsManager { get; } = ServiceBuildingsManagerSingleton.Instance;
        protected override IStructureBuildingsManager StructureBuildingsManager { get; } = StructureBuildingsManagerSingleton.Instance;
    }
}