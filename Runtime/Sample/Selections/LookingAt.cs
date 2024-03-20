using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class LookingAt : Selections
    {
        [SerializeField] private Transform cameraPoint;
        private CharacterMoving characterMoving;
        private CameraMoving cameraMoving;
        private Vector3 previousCameraLocalPosition;
        private Quaternion previousCameraLocalRotation;



        protected override void SetAsThisTypeState(Selector selector)
        {
            if (selector.TryGetComponent(out characterMoving))
            {
                characterMoving.DisableMoving();
            }
        }
        protected override void UnsetAsThisTypeState()
        {
            characterMoving.EnableMoving();
        }
        protected override void OnSelect(Selector selector)
        {
            if (selector.TryGetComponent(out cameraMoving))
            {
                previousCameraLocalPosition = cameraMoving.LocalPosition;
                previousCameraLocalRotation = cameraMoving.LocalRotation;
                cameraMoving.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
            }
            else
            {
                Debug.LogWarning($"No {nameof(CameraMoving)} component in interactor object");
            }
        }
        protected override void OnUnselect()
        {
            cameraMoving.SetLocalPositionAndRotation(previousCameraLocalPosition, previousCameraLocalRotation);
            previousCameraLocalPosition = default;
            previousCameraLocalRotation = default;
        }
    }
}