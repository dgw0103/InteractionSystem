using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace InteractionSystem
{
    [Serializable]
    public class SelectionInput
    {
        [SerializeField] private InputActionReference unselectionActionReference;
        private InputAction unselectionAction;



        public void Init(Action onPerformed)
        {
            unselectionAction = unselectionActionReference.action.Clone();
            unselectionAction.performed += (x) => onPerformed.Invoke();
        }



        public void EnableUnselectionAction()
        {
            unselectionAction.Enable();
        }
        public void DisableUnselectionAction()
        {
            unselectionAction.Disable();
        }
    }
}
