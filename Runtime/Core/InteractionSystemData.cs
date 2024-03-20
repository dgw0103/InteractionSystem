using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace HoJin.InteractionSystem
{
    [CreateAssetMenu(fileName = nameof(InteractionSystemData), menuName = "InteractionSystem/" + nameof(InteractionSystemData))]
    public class InteractionSystemData : ScriptableObject
    {
        public LayerMask interactionLayerMask;
        public LayerMask blockingLayerMask;
    }
}