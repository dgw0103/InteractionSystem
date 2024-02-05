using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HoJin.InteractionSystem
{
    public interface IInteractionEvent
    {
        public void OnStarted(Interactor interactor);
        public void OnPerformed(Interactor interactor);
        public void OnCanceled(Interactor interactor);
    }
}