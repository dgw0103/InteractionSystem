using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace InteractionSystem
{
    [CreateAssetMenu(fileName = "LightEmissionData", menuName = "InteractionSystem/Targeting/LightEmission")]
    public class LightEmissionData : ScriptableObject
    {
        [SerializeField] private Color emissionColor;
        [SerializeField] private string emissionColorKeyword;



        public Color EmissionColor { get => emissionColor; }
        public string EmissionColorKeyword { get => emissionColorKeyword; }
    }
}