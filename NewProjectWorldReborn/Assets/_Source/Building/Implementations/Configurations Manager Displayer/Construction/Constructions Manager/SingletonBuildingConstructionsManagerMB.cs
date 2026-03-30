namespace BuildingSystem.Implementations
{
    public class SingletonBuildingConstructionsManagerMB : ABuildingConstructionsManagerMB
    {
        protected override IStructureBuildingsManager ConstructedBuildingCorrespondancesManager => StructureBuildingsManagerSingleton.Instance;
    }
}