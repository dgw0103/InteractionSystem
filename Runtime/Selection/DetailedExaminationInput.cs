using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
    public class DetailedExaminationInput : IInputMember
    {
        private InputAction rotationActivationAction;
        private InputAction rotationAction;
        private InputAction zoomInOutAction;
        private Action<Vector2> rotate;
        private Action<float> zoomInOut;



        public DetailedExaminationInput(Action<Vector2> rotate, Action<float> zoomInOut)
        {
            InteractionSystemGlobalData.DetailedExaminationData detailedExaminationData = InteractionSystemGlobalData.DetailedExaminationDataInstance;

            rotationActivationAction = detailedExaminationData.RotationActivationActionReference.action.Clone();
            rotationAction = detailedExaminationData.RotationActionReference.action.Clone();
            zoomInOutAction = detailedExaminationData.ZoomInZoomOutActionReference.action.Clone();

            this.rotate = rotate;
            this.zoomInOut = zoomInOut;

            rotationAction.performed += Rotate;
            zoomInOutAction.performed += ZoomInOut;
        }



        public bool IsRotating { get => rotationActivationAction.IsPressed(); }
        private void Rotate(InputAction.CallbackContext callbackContext)
        {
            rotate.Invoke(callbackContext.ReadValue<Vector2>());
        }
        private void ZoomInOut(InputAction.CallbackContext callbackContext)
        {
            zoomInOut.Invoke(callbackContext.ReadValue<float>());
        }
        public void EnableAction()
        {
            rotationActivationAction.Enable();
            rotationAction.Enable();
            zoomInOutAction.Enable();
        }
        public void DisableAction()
        {
            rotationActivationAction.Disable();
            rotationAction.Disable();
            zoomInOutAction.Disable();
        }
    }
}