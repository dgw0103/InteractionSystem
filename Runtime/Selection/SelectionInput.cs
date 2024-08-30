using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace InteractionSystem
{
    internal class SelectionInput : IInputMember
    {
        private InputAction unselectionAction;
        private Action unselect;



        public SelectionInput(Action unselect)
        {
            this.unselectionAction = InteractionSystemGlobalData.SelectionDataInstance.UnselectionActionReference.action.Clone();
            this.unselect = unselect;
            this.unselectionAction.performed += Unselect;
        }




        private void Unselect(InputAction.CallbackContext callbackContext)
        {
            unselect?.Invoke();
        }
        public void EnableAction()
        {
            unselectionAction.Enable();
        }
        public void DisableAction()
        {
            unselectionAction.Disable();
        }
    }
}