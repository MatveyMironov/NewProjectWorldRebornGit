namespace ServiceSystem
{
    public interface IServiceDefinitionDisplayer
    {
        void DisplayServiceDefinition(IServiceDefinition service);
        void Clear();
    }
}