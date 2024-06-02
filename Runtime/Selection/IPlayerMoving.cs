using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public interface IPlayerMoving
    {
        public bool Enabled { get; set; }
        public void SetCameraPositionAndRotation(Vector3 position, Quaternion rotation);
        public Vector3 CameraPosition { get; }
        public Quaternion CameraRotation { get; }
    }
}