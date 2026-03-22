namespace ManufactureSystem.Implementations
{
    public interface IManufacturePauseController
    {
        void ControlManufacture(IManufacture manufacture);
        void ReleaseManufacture();
    }
}