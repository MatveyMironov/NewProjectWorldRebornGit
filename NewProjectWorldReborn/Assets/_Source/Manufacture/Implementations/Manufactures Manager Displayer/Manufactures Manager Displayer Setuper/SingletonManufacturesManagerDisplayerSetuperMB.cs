namespace ManufactureSystem.Implementations
{
    public class SingletonManufacturesManagerDisplayerSetuperMB : AManufacturesManagerDisplayerSetuperMB
    {
        protected override IManufacturesManager ManufacturesManager => ManufacturesManagerSingleton.Instance;
    }
}