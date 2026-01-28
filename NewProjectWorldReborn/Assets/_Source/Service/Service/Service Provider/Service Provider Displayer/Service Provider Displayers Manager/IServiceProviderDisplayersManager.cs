namespace ServiceSystem
{
    public interface IServiceProviderDisplayersManager
    {
        bool TryAddServiceProviderDisplayer(ServiceProvider provider);
        bool TryRemoveServiceProviderDisplayer(ServiceProvider provider);
    }
}