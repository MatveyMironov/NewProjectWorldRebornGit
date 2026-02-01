using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class ResourceCountDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private AResourceCountDisplayerMB resourceCountDisplayer;
        [SerializeField] private ResourceDefinitionSO resource;
        [SerializeField] private int count;

        private void Start()
        {
            resourceCountDisplayer.DisplayResource(resource);
            resourceCountDisplayer.DisplayCount(count);
        }
    }
}