using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HoJin.InteractionSystem
{
    public abstract class Selections : MonoBehaviour, IInteractionEvent
    {
        private static Stack<Selections> currentSelections = new Stack<Selections>();



        public void OnStarted(Interactor interactor)
        {
            
        }
        public void OnPerformed(Interactor interactor)
        {
            if (currentSelections.TryPeek(out Selections selections) == true)
            {
                selections.OnUnselection(interactor);
            }
            OnSelectionAtFirst(interactor);
            currentSelections.Push(this);
        }
        public void OnCanceled(Interactor interactor)
        {
            if (currentSelections.Count > 0)
            {
                OnUnselectionAtFirst(interactor);
                currentSelections.Pop();

                if (currentSelections.TryPeek(out Selections selections))
                {
                    selections.OnSelection(interactor);
                }
            }
        }
        public virtual void OnSelectionAtFirst(Interactor interactor)
        {
            Debug.Log(nameof(OnSelectionAtFirst));
            OnSelection(interactor);
        }
        public virtual void OnUnselectionAtFirst(Interactor interactor)
        {
            OnUnselection(interactor);
        }
        protected abstract void OnSelection(Interactor interactor);
        protected abstract void OnUnselection(Interactor interactor);
        public static void UnselectRecentSelections()
        {
            if (currentSelections.TryPeek(out Selections selections))
            {
                selections.OnCanceled(null);
            }
        }
        public static void UnselectAll()
        {
            while (currentSelections.TryPeek(out Selections selections))
            {
                UnselectRecentSelections();
            }
        }
    }
}