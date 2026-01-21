namespace ConsumptionSystem
{
    public interface IConsumptionController
    {
        void AddConsumption(Consumption consumption);
        void RemoveConsumption(Consumption consumption);
        void Update();
    }
}