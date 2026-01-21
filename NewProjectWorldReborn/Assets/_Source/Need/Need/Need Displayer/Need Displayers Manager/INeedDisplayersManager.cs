namespace NeedSystem
{
    public interface INeedDisplayersManager
    {
        bool TryAddNeed(INeed need);
        bool TryRemoveNeed(INeed need);
    }
}