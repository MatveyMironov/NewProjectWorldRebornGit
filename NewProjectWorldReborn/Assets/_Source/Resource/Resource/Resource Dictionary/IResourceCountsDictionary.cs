using System.Collections.Generic;

namespace ResourceSystem
{
    public interface IResourceCountsDictionary
    {
        Dictionary<IResourceDefinition, int> GetResourceCountsDictionary();
    }
}