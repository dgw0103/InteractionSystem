using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class Targeting : MonoBehaviour
    {
        private bool isTargeted = false;



        protected void OnDisable()
        {
            try
            {
                isTargeted = false;
                SetReleasedState();
            }
            catch (System.Exception)
            {
                Debug.Log("error");
                throw;
            }
            
        }



        public void OnTargeted()
        {
            if (enabled && isTargeted == false)
            {
                isTargeted = true;
                SetTargetedState();
            }
        }
        public void OnReleased()
        {
            if (enabled && isTargeted)
            {
                isTargeted = false;
                SetReleasedState();
            }
        }
        protected abstract void SetTargetedState();
        protected abstract void SetReleasedState();
        public bool Enabled { get => enabled; set => enabled = value; }
    }
}