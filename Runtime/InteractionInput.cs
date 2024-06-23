using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
    public class InteractionInput
    {
        private InputAction interactionAction;



        public InteractionInput(InputActionReference interactionActionReference, Action onStarted, Action onPerformed, Action onCanceled)
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