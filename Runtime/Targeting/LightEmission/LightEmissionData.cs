using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    [CreateAssetMenu(fileName = "LightEmissionData", menuName = "Interaction system/Targeting/Light emission data")]
    public class LightEmissionData : ScriptableObject
    {
        public Color emissionColor = Color.white;
        public string emissionColorKeyword;
    }
}