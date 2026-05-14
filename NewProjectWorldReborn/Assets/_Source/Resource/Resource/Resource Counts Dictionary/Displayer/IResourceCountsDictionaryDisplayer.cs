using System.Collections.Generic;

namespace ResourceSystem
{
    public interface IResourceCountsDictionaryDisplayer
    {
        void DisplayResourceCountsDictionary(Dictionary<IResourceDefinition, int> dictionary);
        void Clear();
    }
}