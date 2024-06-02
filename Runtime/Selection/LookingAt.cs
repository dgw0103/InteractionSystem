using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    [AddComponentMenu(nameof(InteractionSystem) + "/" + nameof(LookingAt))]
    public class LookingAt : Selection
    {
        [SerializeField] private Transform cameraPoint;
        private Vector3 previousCameraPosition;
        private Quaternion previousCameraRotation;



        public override void SetAsThisTypeState(Selector selector)
        {
            if (selector.TryGetComponent(out IPlayerMoving playerMoving))
            {
                playerMoving.Enabled = false;
            }
        }
        public override void UnsetAsThisTypeState(Selector selector)
        {
            if (selector.TryGetComponent(out IPlayerMoving playerMoving))
            {
                playerMoving.Enabled = true;
            }
        }
        public override void OnSelect(Selector selector)
        {
            if (selector.TryGetComponent(out IPlayerMoving playerMoving))
            {
                previousCameraPosition = playerMoving.CameraPosition;
                previousCameraRotation = playerMoving.CameraRotation;
                playerMoving.SetCameraPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
            }
            else
            {
                Debug.LogWarning($"Selector GameObject has not {nameof(IPlayerMoving)} component");
            }
        }
        public override void OnUnselect(Selector selector)
        {
            if (selector.TryGetComponent(out IPlayerMoving playerMoving))
            {
                playerMoving.SetCameraPositionAndRotation(previousCameraPosition, previousCameraRotation);
                previousCameraPosition = default;
                previousCameraRotation = default;
            }
            else
            {
                Debug.LogWarning($"Selector GameObject has not {nameof(IPlayerMoving)} component");
            }
        }
    }
}