using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HoJin.InteractionSystem
{
    [Serializable]
    public abstract class Targeting : MonoBehaviour
    {
        public abstract void OnTargeted();
        public abstract void OnReleased();
    }
}
