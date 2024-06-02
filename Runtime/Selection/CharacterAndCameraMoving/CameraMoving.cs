using UnityEngine;

namespace InteractionSystem
{
    public abstract class CameraMoving : MonoBehaviour
    {
        public abstract void EnableMoving();
        public abstract void DisableMoving();
        public abstract void SetPositionAndRotation(Vector3 position, Quaternion rotation);
        public abstract void SetLocalPositionAndRotation(Vector3 localPosition, Quaternion localRotation);
        public abstract Vector3 LocalPosition { get; }
        public abstract Quaternion LocalRotation { get; }
    }
}