using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
    [Serializable]
    public class InteractionInput
    {
        [SerializeField] private InputActionReference interactionActionReference;
        private InputAction interactionAction;



        public void Init(Action onStarted, Action onPerformed, Action onCanceled)
        {
            interactionAction = interactionActionReference.action.Clone();
            interactionAction.started += (x) => onStarted?.Invoke();
            interactionAction.performed += (x) => onPerformed?.Invoke();
            interactionAction.canceled += (x) => onCanceled?.Invoke();
        }

        

        public void EnableInteractionAction()
        {
            interactionAction.Enable();
        }
        public void DisableInteractionAction()
        {
            interactionAction.Disable();
        }
    }
}