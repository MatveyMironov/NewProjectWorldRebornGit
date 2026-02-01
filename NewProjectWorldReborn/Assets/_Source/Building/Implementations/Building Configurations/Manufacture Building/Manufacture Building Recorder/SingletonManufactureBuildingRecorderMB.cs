namespace BuildingSystem.Implementations
{
    public class SingletonManufactureBuildingRecorderMB : AManufactureBuildingRecorderMB
    {
        private IBuildingManufacturesManager _buildingManufacturesManager;
        protected override IBuildingManufacturesManager BuildingManufacturesManager => _buildingManufacturesManager;

        protected virtual void Awake()
        {
            _buildingManufacturesManager = BuildingManufacturesManagerSingleton.Instance;
        }
    }
}