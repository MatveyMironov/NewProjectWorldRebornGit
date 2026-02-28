namespace ServiceSystem
{
    public interface IServiceProviderDisplayersManager
    {
        void RemoveAllDisplayers();
        bool TryAddDisplayer(ServiceProvider provider);
        bool TryRemoveDisplayer(ServiceProvider provider);
    }
}