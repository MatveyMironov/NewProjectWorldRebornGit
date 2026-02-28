namespace ServiceSystem.Testing
{
    public interface IServiceProviderCreationButtonsManager
    {
        bool TryAddButton(IServiceDefinition service, int providedAmount);
        bool TryRemoveButton(IServiceDefinition service);
    }
}