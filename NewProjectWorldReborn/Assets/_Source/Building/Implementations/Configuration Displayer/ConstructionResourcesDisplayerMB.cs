using ResourceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class ConstructionResourcesDisplayerMB : ABuildingConfigurationDisplayerMB
    {
        [SerializeField] private AResourceCountDisplayerMB resourceCountDisplayerPrefab;
        [SerializeField] private Transform content;

        private readonly List<AResourceCountDisplayerMB> _createdDisplayers = new();

        public override void Clear()
        {
            int createdDisplayersCount = _createdDisplayers.Count;

            for (int i = 0; i < createdDisplayersCount; i++)
            {
                _createdDisplayers.RemoveAt(0);
            }
        }

        public override void DisplayBuildingConiguration(IBuildingConfiguration configuration)
        {
            Dictionary<IResourceDefinition, int> constructionResourcesDictionary = configuration.ConstructionResourcesDictionary;

            if (constructionResourcesDictionary.Count <= 0)
            {
                Debug.Log(0);
                Hide();
                return;
            }

            Show();

            foreach (var resourceCount in constructionResourcesDictionary)
            {
                IResourceDefinition resource = resourceCount.Key;
                int count = resourceCount.Value;

                AResourceCountDisplayerMB resourceCountDisplayer = Instantiate(resourceCountDisplayerPrefab, content);

                resourceCountDisplayer.DisplayResource(resource);
                resourceCountDisplayer.DisplayCount(count);

                _createdDisplayers.Add(resourceCountDisplayer);
            }
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
