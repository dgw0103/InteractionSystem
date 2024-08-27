using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
    public class InteractionSystemGlobalData : MonoBehaviour
    {
        [SerializeField] private LayerMask interactionLayerMask;
        [SerializeField] private LayerMask blockingLayerMask;
        [SerializeField] private InputActionReference inputActionReference;

        private static InteractionSystemGlobalData instance;



        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }



        public static InteractionSystemGlobalData Instance { get => instance; }
    }
}