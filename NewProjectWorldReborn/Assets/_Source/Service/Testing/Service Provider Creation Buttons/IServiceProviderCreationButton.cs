using System;

namespace ServiceSystem.Testing
{
    public interface IServiceProviderCreationButton
    {
        event Action OnButtonClicked;

        void Destroy();
        void DisplayCreatedServiceSupply(IServiceDefinition serviceDefinition, int suppliedAmount);
        void HideCreatedServiceProvider();
    }
}