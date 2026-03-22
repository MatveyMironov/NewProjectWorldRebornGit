using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem
{
    public abstract class AResourceCountsDictionaryDisplayerMB : MonoBehaviour, IResourceCountsDictionaryDisplayer
    {
        public abstract void DisplayResourceCountsDictionary(Dictionary<IResourceDefinition, int> dictionary);
        public abstract void Clear();
    }
}