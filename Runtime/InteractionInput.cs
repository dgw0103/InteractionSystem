using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
    internal class InteractionInput : IInputMember
    {
        private readonly InputAction interactionAction;



        public InteractionInput(Action onStarted, Action onPerformed, Action onCanceled)
        {
            interactionAction = InteractionSystemGlobalData.InteractionSystemDataInstance.InputActionReference.action.Clone();
            interactionAction.started += (x) => onStarted?.Invoke();
            interactionAction.performed += (x) => onPerformed?.Invoke();
            interactionAction.canceled += (x) => onCanceled?.Invoke();
        }

        

        public void EnableAction()
        {
            interactionAction.Enable();
        }
        public void DisableAction()
        {
            interactionAction.Disable();
        }
    }
}