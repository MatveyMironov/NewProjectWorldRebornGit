using UnityEngine;

namespace ResourceSystem
{
    [CreateAssetMenu(fileName = "New Resource", menuName = "Resource")]
    public class ResourceDefinitionSO : ScriptableObject, IResourceDefinition
    {
        // TODO: links instead of strings
        [SerializeField] private new string name;
        [SerializeField] private string description;
        [SerializeField] private Sprite icon;

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public Sprite Icon { get { return icon; } }
    }
}