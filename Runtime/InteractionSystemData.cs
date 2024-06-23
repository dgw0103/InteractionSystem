using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace InteractionSystem
{
    [Serializable]
    public class InteractionSystemData : ScriptableObject
    {
        [SerializeField] private LayerMask interactionLayerMask;
        [SerializeField] private LayerMask blockingLayerMask;
        [SerializeField] private InputActionReference inputActionReference;



        public LayerMask InteractionLayerMask { get => interactionLayerMask; }
        public  LayerMask BlockingLayerMask { get => blockingLayerMask; }
        public InputActionReference InputActionReference { get => inputActionReference; }
    }
}