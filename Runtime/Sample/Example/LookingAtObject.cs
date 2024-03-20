using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class LookingAtObject : InteractionObject
    {
        private LookingAt lookingAt;

        

        protected new void Awake()
        {
            base.Awake();
            TryGetComponent(out lookingAt);
        }



        public override void OnInteractionStarted(Interactor interactor)
        {
        }
        public override void OnInteractionPerformed(Interactor interactor)
        {
            if (interactor.TryGetComponent(out Selector selector))
            {
                lookingAt.Select(selector);
            }
        }
        public override void OnInteractionCanceled(Interactor interactor)
        {
        }
    }
}