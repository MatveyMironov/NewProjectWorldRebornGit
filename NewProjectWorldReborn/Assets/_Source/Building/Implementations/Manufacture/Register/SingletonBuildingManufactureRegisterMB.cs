using ManufactureSystem;

namespace BuildingSystem.Implementations.Manufacture
{
    public class SingletonBuildingManufactureRegisterMB : ABuildingManufactureRegisterMB
    {
        protected override IStructureBuildingsManager BuildingsManager => StructureBuildingsManagerSingleton.Instance;
        protected override IManufacturesManager ManufacturesManager => ManufacturesManagerSingleton.Instance;
    }
}