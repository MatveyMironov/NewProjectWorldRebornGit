namespace ResourceSystem
{
    public interface IResourceCountDisplayer
    {
        void DisplayResource(IResourceDefinition resource);
        void DisplayCount(int count);
    }
}