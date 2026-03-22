namespace ManufactureSystem.Implementations
{
    public interface IManufactureProgressDisplayer
    {
        public void DisplayManufacture(IManufacture manufacture);
        public void Clear();
    }
}