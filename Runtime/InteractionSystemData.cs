using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using System;
using UnityEngine.Serialization;

namespace InteractionSystem
{
    [Serializable]
    public class InteractionSystemData : ScriptableObject
    {
        [SerializeField, FormerlySerializedAs(nameof(interactionLayerMask))] private LayerMask interactionLayerMaskField;
        [SerializeField, FormerlySerializedAs(nameof(blockingLayerMask))] private LayerMask blockingLayerMaskField;
        [SerializeField, FormerlySerializedAs(nameof(inputActionReference))] private InputActionReference inputActionReferenceField;
        public static LayerMask interactionLayerMask;
        public static LayerMask blockingLayerMask;
        public static InputActionReference inputActionReference;
    }
}