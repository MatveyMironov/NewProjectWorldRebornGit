
using ServiceSystem;

namespace BuildingSystem.Implementations.Service
{
    public class SingletonServiceBuildingRegisterMB : AServiceBuildingRegisterMB
    {
        protected override IStructureBuildingsManager BuildingsManager { get; } = StructureBuildingsManagerSingleton.Instance;
        protected override IServiceProvidersManager ServiceProvidersManager { get; } = ServiceProvidersManagerSingleton.Instance;
    }
}