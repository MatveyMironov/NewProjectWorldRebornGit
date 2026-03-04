using System.Collections.Generic;
using UnityEngine;

namespace CustomUtilities.RendererUtilities
{
    public class MultipleRenderersMaterialsSwitcher
    {
        private readonly List<IndividualRendererMaterialsSwitcher> _individualRendererMaterialsSwitcher;

        public MultipleRenderersMaterialsSwitcher(GameObject gameObject)
        {
            _individualRendererMaterialsSwitcher = new();

            CreateIndividualRendererMaterialsSwitchers(gameObject);
        }

        private void CreateIndividualRendererMaterialsSwitchers(GameObject gameObject)
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer renderer in renderers)
            {
                IndividualRendererMaterialsSwitcher rendererMaterialsSwitcher = new(renderer);
                _individualRendererMaterialsSwitcher.Add(rendererMaterialsSwitcher);
            }
        }

        public void SwitchMaterialsWithMaterial(Material material)
        {
            foreach (IndividualRendererMaterialsSwitcher switcher  in _individualRendererMaterialsSwitcher)
            {
                switcher.SwitchMaterial(material);
            }
        }

        public void ReturnDefaultMaterials()
        {
            foreach (IndividualRendererMaterialsSwitcher switcher in _individualRendererMaterialsSwitcher)
            {
                switcher.ReturnDefaultMaterials();
            }
        }

        private class IndividualRendererMaterialsSwitcher
        {
            private readonly Renderer _renderer;
            private readonly Material[] _materials;

            public IndividualRendererMaterialsSwitcher(Renderer renderer)
            {
                _renderer = renderer;

                _materials = _renderer.materials;
            }

            public void SwitchMaterial(Material material)
            {
                _renderer.material = material;
            }

            public void ReturnDefaultMaterials()
            {
                _renderer.materials = _materials;
            }
        }
    }
}
