using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class Targeting : MonoBehaviour
    {
        protected void OnDisable()
        {
            OnReleased();
        }



        public abstract void OnTargeted();
        public abstract void OnReleased();
        public bool Enabled { get => enabled; set => enabled = value; }
    }
}