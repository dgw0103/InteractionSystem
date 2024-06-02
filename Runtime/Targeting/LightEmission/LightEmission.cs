using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(LightEmission))]
    public class LightEmission : MonoBehaviour, ITargeting
    {
        [SerializeField] private RendererIntHashsetDictionary except;
        [SerializeField] private LightEmissionData lightEmissionData;
        private List<Material> materials = new List<Material>();
        private Color[] previousTargetingColors;



        private void Awake()
        {
            foreach (var meshRenderer in GetComponentsInChildren<Renderer>(true))
            {
                if (except.TryGetValue(meshRenderer, out IntHashset intHashSet))
                {
                    int[] materials = new int[meshRenderer.sharedMaterials.Length];



                    for (int i = 0; i < materials.Length; i++)
                    {
                        materials[i] = i;
                    }
                    materials = materials.Except(intHashSet).ToArray().Clone() as int[];
                    foreach (var index in materials)
                    {
                        this.materials.Add(meshRenderer.materials[index]);
                    }
                }
                else
                {
                    foreach (var material in meshRenderer.materials)
                    {
                        materials.Add(material);
                    }
                }
            }
            previousTargetingColors = new Color[materials.Count];
        }



        public void OnTargeted()
        {
            for (int i = 0; i < materials.Count; i++)
            {
                previousTargetingColors[i] = materials[i].GetColor(lightEmissionData.EmissionColorKeyword);
                materials[i].SetColor(lightEmissionData.EmissionColorKeyword, lightEmissionData.EmissionColor);
            }
        }
        public void OnReleased()
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].SetColor(lightEmissionData.EmissionColorKeyword, previousTargetingColors[i]);
            }
        }
    }
}