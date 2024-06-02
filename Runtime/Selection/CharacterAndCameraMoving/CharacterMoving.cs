using UnityEngine;

namespace InteractionSystem
{
    public abstract class CharacterMoving : MonoBehaviour
    {
        public abstract void EnableMoving();
        public abstract void DisableMoving();
    }
}