using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HoJin.InteractionSystem
{
    public class DefaultInteractionEvent : IInteractionEvent
    {
        public void OnStarted(Interactor interactor)
        {
            Debug.Log(nameof(OnStarted));
        }
        public void OnPerformed(Interactor interactor)
        {
            Debug.Log(nameof(OnPerformed));
        }
        public void OnCanceled(Interactor interactor)
        {
            Debug.Log(nameof(OnCanceled));
        }
    }
}