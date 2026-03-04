namespace ManufactureSystem.Testing
{
    public class SingletonTestManufacturesMB : ATestManufacturesMB
    {
        protected override IManufacturesManager ManufacturesManager => ManufacturesManagerSingleton.Instance;
    }
}