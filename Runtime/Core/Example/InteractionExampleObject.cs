using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class InteractionExampleObject : InteractionObject
    {
        public override void OnInteractionStarted(Interactor interactor)
        {
        }
        public override void OnInteractionPerformed(Interactor interactor)
        {
            Debug.Log("Interacted");
        }
        public override void OnInteractionCanceled(Interactor interactor)
        {
        }
    }
}
