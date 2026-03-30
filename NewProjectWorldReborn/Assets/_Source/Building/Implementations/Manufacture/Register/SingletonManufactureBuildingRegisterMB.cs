using ManufactureSystem;

namespace BuildingSystem.Implementations
{
    public class SingletonManufactureBuildingRegisterMB : AManufactureBuildingRegisterMB
    {
        protected override IStructureBuildingsManager BuildingsManager => StructureBuildingsManagerSingleton.Instance;
        protected override IManufacturesManager ManufacturesManager => ManufacturesManagerSingleton.Instance;
    }
}