using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public interface IPlayerMoving
    {
        bool Enabled { get; set; }
        void SetCameraPositionAndRotation(Vector3 position, Quaternion rotation);
        Vector3 CameraPosition { get; }
        Quaternion CameraRotation { get; }
    }
}