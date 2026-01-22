namespace ResourceSystem
{
    public interface IResourceCountDisplayersManager
    {
        public void DisplayResourceCount(IResourceDefinition resource, int count);
        public void Clear();
    }
}