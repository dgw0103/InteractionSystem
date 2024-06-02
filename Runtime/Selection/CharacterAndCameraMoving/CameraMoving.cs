using UnityEngine;

namespace InteractionSystem
{
    public interface CameraMoving
    {
        public void EnableMoving();
        public void DisableMoving();
        public void SetPositionAndRotation(Vector3 position, Quaternion rotation);
        public void SetLocalPositionAndRotation(Vector3 localPosition, Quaternion localRotation);
        public Vector3 LocalPosition { get; }
        public Quaternion LocalRotation { get; }
    }
}