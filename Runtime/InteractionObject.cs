using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace HoJin.InteractionSystem
{
    public abstract class InteractionObject : MonoBehaviour
    {
        public abstract void OnInteractionStarted(Interactor interactor);
        public abstract void OnInteractionPerformed(Interactor interactor);
        public abstract void OnInteractionCanceled(Interactor interactor);
    }
}