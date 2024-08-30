using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace InteractionSystem
{
    public struct InputMemberConstructorParameter
    {
        public InputActionReference inputActionReference;
        public Action<InputAction.CallbackContext> onStarted;
        public Action<InputAction.CallbackContext> onPerformed;
        public Action<InputAction.CallbackContext> onCanceled;



        public InputMemberConstructorParameter(InputActionReference inputActionReference, Action<InputAction.CallbackContext> onPerformed)
        {
            this.inputActionReference = inputActionReference;
            this.onStarted = null;
            this.onPerformed = onPerformed;
            this.onCanceled = null;
        }
        public InputMemberConstructorParameter(InputActionReference inputActionReference, Action onPerformed)
        {
            this.inputActionReference = inputActionReference;
            this.onStarted = null;
            this.onPerformed = (x) => onPerformed?.Invoke();
            this.onCanceled = null;
        }
        public InputMemberConstructorParameter(InputActionReference inputActionReference, Action<InputAction.CallbackContext> onStarted,
            Action<InputAction.CallbackContext> onPerformed, Action<InputAction.CallbackContext> onCanceled)
        {
            this.inputActionReference = inputActionReference;
            this.onStarted = onStarted;
            this.onPerformed = onPerformed;
            this.onCanceled = onCanceled;
        }
    }
}