using ConsumptionSystem;

namespace NeedSystem.Implementations
{
    public interface IResourceNeedsManager
    {
        bool TryAddResourceNeedConsumption(ConsumptionNeed need, Consumption consumption);
        bool TryRemoveResourceNeedConsumption(ConsumptionNeed need);
    }
}