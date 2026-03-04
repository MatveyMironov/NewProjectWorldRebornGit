using EfficiencySystem;

namespace ManufactureSystem
{
    public interface IManufactureConfiguration
    {
        IManufacture CreateManufacture(IEfficiency efficiency);
    }
}