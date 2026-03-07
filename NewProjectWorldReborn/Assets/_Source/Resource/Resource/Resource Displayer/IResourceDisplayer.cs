namespace ResourceSystem
{
    public interface IResourceDisplayer
    {
        void DisplayResource(IResourceDefinition resource);
        void Clear();
    }
}