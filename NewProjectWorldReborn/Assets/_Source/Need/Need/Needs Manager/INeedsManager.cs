using System;

namespace NeedSystem
{
    public interface INeedsManager
    {
        INeed[] Needs { get; }

        event Action<INeed> OnNeedAdded;
        event Action<INeed> OnNeedRemoved;

        bool TryAddNeed(INeed demand);
        bool TryRemoveNeed(INeed demand);
    }
}