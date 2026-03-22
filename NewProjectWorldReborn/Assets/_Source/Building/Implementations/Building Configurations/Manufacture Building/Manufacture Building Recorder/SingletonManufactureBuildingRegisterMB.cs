namespace BuildingSystem.Implementations
{
    public class SingletonManufactureBuildingRegisterMB : AManufactureBuildingRegisterMB
    {
        protected override IBuildingManufacturesManager BuildingManufacturesManager => BuildingManufacturesManagerSingleton.Instance;
        protected override IStructureBuildingsManager StructureBuildingsManager => StructureBuildingsManagerSingleton.Instance;
    }
}