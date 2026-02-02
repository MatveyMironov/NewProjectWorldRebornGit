namespace BuildingSystem.Implementations
{
    public class SingletonServiceBuildingRegisterMB : AServiceBuildingRegisterMB
    {
        protected override IServiceBuildingsManager ServiceBuildingsManager => ServiceBuildingsManagerSingleton.Instance;
    }
}