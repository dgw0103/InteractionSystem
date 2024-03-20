using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace HoJin.InteractionSystem
{
    public abstract class InteractionObject : MonoBehaviour
    {
        private Targeting targeting;



        protected void Awake()
        {
            TryGetComponent(out targeting);
        }



        public void OnTargeted()
        {
            if (targeting)
            {
                targeting.OnTargeted();
            }
        }
        public void OnReleased()
        {
            if (targeting)
            {
                targeting.OnReleased();
            }
        }
        public abstract void OnInteractionStarted(Interactor interactor);
        public abstract void OnInteractionPerformed(Interactor interactor);
        public abstract void OnInteractionCanceled(Interactor interactor);
    }
}