using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtility;

namespace InteractionSystem
{
    public class DetailedExamining : Examining
    {
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;
        [SerializeField] private InputActionReference rotationActivationActionReference;
        [SerializeField] private InputActionReference rotationActionReference;
        [SerializeField] private InputActionReference zoomInZoomOutActionReference;
        private InputAction rotationActivationAction;
        private InputAction rotationAction;
        private InputAction zoomInZoomOutAction;
        private Transform selector;
        private float originalDistanceOffset;
        private Quaternion originalRotationOffset;



        private void Awake()
        {
            rotationActivationAction = rotationActivationActionReference.action.Clone();
            rotationAction = rotationActionReference.action.Clone();
            zoomInZoomOutAction = zoomInZoomOutActionReference.action.Clone();

            zoomInZoomOutAction.performed += ZoomInZoomOut;
            rotationAction.performed += Rotate;
        }



        protected override void OnSelect(Selector selector)
        {
            base.OnSelect(selector);

            originalDistanceOffset = DistanceOffset;
            originalRotationOffset = RotationOffset;
            this.selector = selector.transform;

            rotationActivationAction.Enable();
            rotationAction.Enable();
            zoomInZoomOutAction.Enable();
        }
        protected override void OnUnselect(Selector selector)
        {
            base.OnUnselect(selector);

            DistanceOffset = originalDistanceOffset;
            RotationOffset = originalRotationOffset;
            this.selector = null;

            rotationActivationAction.Disable();
            rotationAction.Disable();
            zoomInZoomOutAction.Disable();
        }
        private void Rotate(InputAction.CallbackContext callbackContext)
        {
            if (rotationActivationAction.IsPressed())
            {
                Rotate(callbackContext.ReadValue<Vector2>());
            }
        }
        private void Rotate(Vector2 value)
        {
            Vector2 rotationValue = rotationSpeed * value;

            RotationOffset *= Quaternion.AngleAxis(-rotationValue.x, Quaternion.Inverse(transform.rotation) * selector.up);
            RotationOffset *= Quaternion.AngleAxis(rotationValue.y, Quaternion.Inverse(transform.rotation) * selector.right);
        }
        private void ZoomInZoomOut(InputAction.CallbackContext callbackContext)
        {
            ZoomInZoomOut(callbackContext.ReadValue<float>());
        }
        private void ZoomInZoomOut(float value)
        {
            float scrollDirection = value / Mathf.Abs(value);
            float afterValue = Mathf.Round(DistanceOffset + scrollDirection);



            if (afterValue >= minDistance && afterValue <= maxDistance)
            {
                DistanceOffset += scrollDirection;
            }
        }
    }
}