using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HoJin.InteractionSystem
{
    [Serializable]
    public abstract class Targeting : MonoBehaviour
    {
        [SerializeField] private int priority;



        public abstract void OnTargeted();
        public abstract void OnReleased();
        public int Priority { get => priority; }
    }
}
