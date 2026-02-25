namespace ServiceSystem
{
    public interface IServiceBalanceDisplayer
    {
        void DisplayServiceBalance(IServiceDefinition service);
        void Clear();
    }
}