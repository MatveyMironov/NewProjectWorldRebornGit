namespace ServiceSystem.Implementations
{
    public class SingletonServiceProvidersManagerDisplayerSetuperMB : AServiceProvidersManagerDisplayerSetuperMB
    {
        protected override IServiceProvidersManager Manager { get; } = ServiceProvidersManagerSingleton.Instance;
    }
}