using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(LookingAt))]
    public class LookingAt : Selection
    {
        [SerializeField] private Transform cameraPoint;
        private CharacterMoving characterMoving;
        private CameraMoving cameraMoving;
        private Vector3 previousCameraLocalPosition;
        private Quaternion previousCameraLocalRotation;



        public override void SetAsThisTypeState(Selector selector)
        {
            if (selector.TryGetComponent(out characterMoving))
            {
                characterMoving.DisableMoving();
            }
        }
        public override void UnsetAsThisTypeState(Selector selector)
        {
            characterMoving.EnableMoving();
        }
        public override void OnSelect(Selector selector)
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
        public override void OnUnselect(Selector selector)
        {
            cameraMoving.SetLocalPositionAndRotation(previousCameraLocalPosition, previousCameraLocalRotation);
            previousCameraLocalPosition = default;
            previousCameraLocalRotation = default;
        }
    }
}