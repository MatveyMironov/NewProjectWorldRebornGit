namespace ManufactureSystem
{
    public interface IManufactureController
    {
        public bool TryAddManufacture(IManufacture manufacture);
        public bool TryRemoveManufacture(IManufacture manufacture);
        public void Update();
    }
}